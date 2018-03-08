namespace PiFormance.Server
{
	using System;

	internal class Program
	{
		private static bool _showConsole = true;

		private static void Main(string[] args)
		{
			if (_showConsole)
			{
				new ConsolePresenter(new ConsoleNativeMethods()).ShowConsole();
				Console.WriteLine("Console is being shown");
			}

			using (var server = new Server())
			{
				server.Run(_showConsole);
			}
		}
	}
}