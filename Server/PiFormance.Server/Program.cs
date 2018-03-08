namespace PiFormance.Server
{
	internal class Program
	{
		private static readonly bool _showConsole = true;

		private static void Main(string[] args)
		{
			if (_showConsole)
			{
				new ConsolePresenter(new ConsoleNativeMethods()).ShowConsole();
			}

			using (var server = new Server())
			{
				server.Run(_showConsole);
			}
		}
	}
}