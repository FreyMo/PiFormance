namespace PiFormance.Server
{
	using System;
	using System.IO;
	using Core.Standard.ArgumentMust;

	public class ConsolePresenter
	{
		private const int StandardOutputHandle = -11;
		private const int UnicodeCodePage = 437;
		private readonly ConsoleNativeMethods _consoleNativeMethods;

		public ConsolePresenter(ConsoleNativeMethods consoleNativeMethods)
		{
			ArgumentMust.NotBeNull(() => consoleNativeMethods);

			_consoleNativeMethods = consoleNativeMethods;
		}

		public void ShowConsole()
		{
			_consoleNativeMethods.AllocateConsole();

			var stdHandle = _consoleNativeMethods.GetStandardHandle(StandardOutputHandle);
			var safeFileHandle = new Microsoft.Win32.SafeHandles.SafeFileHandle(stdHandle, true);
			var fileStream = new FileStream(safeFileHandle, FileAccess.Write);
			var encoding = System.Text.Encoding.GetEncoding(UnicodeCodePage);
			var standardOutput = new StreamWriter(fileStream, encoding) { AutoFlush = true };

			Console.SetOut(standardOutput);
		}
	}
}