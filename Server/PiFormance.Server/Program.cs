namespace PiFormance.Server
{
	using Console;

	internal class Program
	{
		private static readonly bool _showConsole = false;

		private static void Main(string[] args)
		{
			new AutostartProvider().RunOnWindowsStartup();

			if (_showConsole)
			{
				new ConsolePresenter(new ConsoleNativeMethods()).ShowConsole();
			}

			using (var server = new Server())
			{
				server.Run();
			}
		}
	}
}