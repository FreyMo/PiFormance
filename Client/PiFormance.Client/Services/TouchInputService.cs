namespace PiFormance.Client.Services
{
	using System;
	using System.Threading.Tasks;
	using Windows.System.Profile;
	using Windows.UI.Core;
	using Windows.UI.Input.Preview.Injection;
	using Windows.UI.Xaml;
	using Core.Standard.Dispose;
	using Core.Standard.Extensions;
	using TouchPanels;
	using TouchPanels.Devices;
	using Views.Main;
	using PointerEventArgs = TouchPanels.PointerEventArgs;

	public class TouchInputService : DisposableBase
	{
		private const string CalibrationFileName = "TSC2046_Calibration";
		private readonly InputInjector _inputInjector = InputInjector.TryCreate();
		private TouchProcessor _processor;
		private Tsc2046 _tsc2046;
		private bool _isInitialized;

		public async Task InitializeAsync()
		{
			if (!_isInitialized)
			{
				_isInitialized = true;

				if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.IoT")
				{
					HideCursor();
					_tsc2046 = await InitializeTouchControllerAsync();
					_processor = InitializeTouchProcessor(_tsc2046);
				}
			}
		}

		private async Task<Tsc2046> InitializeTouchControllerAsync()
		{
			var tsc2046 = await Tsc2046.GetDefaultAsync();

			try
			{
				await tsc2046.LoadCalibrationAsync(CalibrationFileName);
			}
			catch (System.IO.FileNotFoundException)
			{
				await CalibrateTouch(tsc2046);
			}

			return tsc2046;
		}

		private TouchProcessor InitializeTouchProcessor(ITouchDevice touchDevice)
		{
			var processor = new TouchProcessor(touchDevice);

			processor.PointerDown += TouchedDown;
			processor.PointerUp += TouchedUp;

			return processor;
		}

		private static void HideCursor()
		{
			// CoreWindow.GetForCurrentThread().PointerCursor = null;
			// Window.Current.CoreWindow.PointerCursor = null;
		}

		private void TouchedDown(object sender, PointerEventArgs e)
		{
			var x = Convert.ToUInt16(e.Position.X.Inbetween(0, 800) / 800.0 * ushort.MaxValue);
			var y = Convert.ToUInt16(e.Position.Y.Inbetween(0, 480) / 480.0 * ushort.MaxValue);

			var data = (uint)(x << 16) | (uint)(y << 0);

			var moveInfo = new InjectedInputMouseInfo
			{
				DeltaX = x,
				DeltaY = y,
				MouseData = data,
				MouseOptions = InjectedInputMouseOptions.Move | InjectedInputMouseOptions.Absolute
			};

			var downInfo = new InjectedInputMouseInfo
			{
				DeltaX = 0,
				DeltaY = 0,
				MouseData = data,
				MouseOptions = InjectedInputMouseOptions.LeftDown
			};

			_inputInjector.InjectMouseInput(new[] {moveInfo, downInfo});
		}

		private void TouchedUp(object sender, PointerEventArgs e)
		{
			var x = Convert.ToUInt16(e.Position.X.Inbetween(0, 800) / 800.0 * ushort.MaxValue);
			var y = Convert.ToUInt16(e.Position.Y.Inbetween(0, 480) / 480.0 * ushort.MaxValue);

			var data = (uint)(x << 16) | (uint)(y << 0);

			var upInfo = new InjectedInputMouseInfo
			{
				DeltaX = 0,
				DeltaY = 0,
				MouseData = data,
				MouseOptions = InjectedInputMouseOptions.LeftUp | InjectedInputMouseOptions.Absolute
			};

			_inputInjector.InjectMouseInput(upInfo.ToEnumerable());
		}

		private async Task CalibrateTouch(Tsc2046 touchDevice)
		{
			var calibration = await TouchPanels.UI.LcdCalibrationView.CalibrateScreenAsync(touchDevice);
			touchDevice.SetCalibration(calibration.A, calibration.B, calibration.C, calibration.D, calibration.E, calibration.F);

			await touchDevice.SaveCalibrationAsync(CalibrationFileName);
		}

		protected override void DisposeManagedResources()
		{
			if (_processor != null)
			{
				_processor.PointerDown -= TouchedDown;
				_processor.PointerUp -= TouchedUp;
			}
		}

		private uint GetPointerData(PointerEventArgs e)
		{
			var x = Convert.ToUInt16(e.Position.X.Inbetween(0, 800) / 800.0 * ushort.MaxValue);
			var y = Convert.ToUInt16(e.Position.Y.Inbetween(0, 480) / 480.0 * ushort.MaxValue);

			return (uint)(x << 16) | (uint)(y << 0);
		}
	}
}
