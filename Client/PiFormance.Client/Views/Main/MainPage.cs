namespace PiFormance.Client.Views.Main
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Windows.Foundation;
	using Windows.System.Profile;
	using Windows.UI.Input.Preview.Injection;
	using Windows.UI.Xaml.Automation;
	using Windows.UI.Xaml.Automation.Provider;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Navigation;
	using TouchPanels;
	using TouchPanels.Devices;

	public sealed partial class MainPage : Page
	{
		private const string CalibrationFileName = "TSC2046";
		private bool _isCalibrating;
		private TouchProcessor _processor;
		private Tsc2046 _tsc2046;
		private IScrollProvider currentScrollItem;
		private Point lastPosition = new Point(double.NaN, double.NaN);

		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			{
				Init();
			}
		}

		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			if (_processor != null)
			{
				_processor.PointerDown -= TouchedDown;
				_processor.PointerMoved -= TouchMoved;
				_processor.PointerUp -= TouchedUp;
			}

			base.OnNavigatingFrom(e);
		}

		private async void Init()
		{
			_tsc2046 = await Tsc2046.GetDefaultAsync();

			try
			{
				await _tsc2046.LoadCalibrationAsync(CalibrationFileName);
			}
			catch (System.IO.FileNotFoundException)
			{
				await CalibrateTouch();
			}

			_processor = new TouchProcessor(_tsc2046);

			_processor.PointerDown += TouchedDown;
			_processor.PointerMoved += TouchMoved;
			_processor.PointerUp += TouchedUp;
		}

		private void TouchedDown(object sender, PointerEventArgs e)
		{
			var inputInjector = InputInjector.TryCreate();
			
			ushort x = 0;
			ushort y = 0;

			try
			{
				x = Convert.ToUInt16(e.Position.X / 800.0 * ushort.MaxValue);
				y = Convert.ToUInt16(e.Position.Y / 480.0 * ushort.MaxValue);
			}
			catch (OverflowException)
			{
				x = ushort.MaxValue;
				y = ushort.MaxValue;
			}

			var data = (uint)(x << 16) | (uint)(y << 0);

			var moveInfo1 = new InjectedInputMouseInfo
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
			
			var upInfo = new InjectedInputMouseInfo
			{
				DeltaX = 0,
				DeltaY = 0,
				MouseData = data,
				MouseOptions = InjectedInputMouseOptions.LeftUp
			};

			var moveToOrigin = new InjectedInputMouseInfo
			{
				DeltaX = 0,
				DeltaY = 0,
				MouseData = data,
				MouseOptions = InjectedInputMouseOptions.Move | InjectedInputMouseOptions.Absolute
			};

			var list = new List<InjectedInputMouseInfo>
			{
				moveInfo1,
				downInfo,
				upInfo,
				moveToOrigin
			};

			inputInjector.InjectMouseInput(list);
		}

		private void TouchMoved(object sender, PointerEventArgs e)
		{
			if (currentScrollItem != null)
			{
				var dx = e.Position.X - lastPosition.X;
				var dy = e.Position.Y - lastPosition.Y;

				if (!currentScrollItem.HorizontallyScrollable)
				{
					dx = 0;
				}

				if (!currentScrollItem.VerticallyScrollable)
				{
					dy = 0;
				}

				var h = ScrollAmount.NoAmount;
				var v = ScrollAmount.NoAmount;
				if (dx < 0)
					h = ScrollAmount.SmallIncrement;
				else if (dx > 0)
					h = ScrollAmount.SmallDecrement;
				if (dy < 0)
					v = ScrollAmount.SmallIncrement;
				else if (dy > 0)
					v = ScrollAmount.SmallDecrement;
				currentScrollItem.Scroll(h, v);
			}

			lastPosition = e.Position;
		}

		private void TouchedUp(object sender, PointerEventArgs e)
		{
			currentScrollItem = null;
		}

		private async Task CalibrateTouch()
		{
			_isCalibrating = true;
			var calibration = await TouchPanels.UI.LcdCalibrationView.CalibrateScreenAsync(_tsc2046);
			_isCalibrating = false;
			_tsc2046.SetCalibration(calibration.A, calibration.B, calibration.C, calibration.D, calibration.E, calibration.F);

			await _tsc2046.SaveCalibrationAsync(CalibrationFileName);
		}
	}
}