namespace PiFormance.Server
{
	using System;
	using System.Threading;
	using Console;

	internal class Program
	{
		private static void Main(string[] args)
		{
			if (true)
			{
				new ConsolePresenter(new ConsoleNativeMethods()).ShowConsole();
			}

			AutostartProvider.RunOnWindowsStartup();

			try
			{
				using (var server = new Server())
				{
					server.Run();
				}
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e);

				while (true)
				{
					Thread.Sleep(100);
				}
			}
		}
	}
}