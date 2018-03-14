namespace PiFormance.Server
{
	using System;
	using System.Threading;
	using Functional;

	internal class Program
	{
		private static void Main(string[] args)
		{
			new ConsolePresenter(new ConsoleNativeMethods()).ShowConsole();

			AdminElevator.EnsureAdminRights();
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
				Console.WriteLine(e);

				while (true)
				{
					Thread.Sleep(100);
				}
			}
		}
	}
}