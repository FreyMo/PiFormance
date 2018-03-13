namespace PiFormance.Server
{
	using System;
	using System.Threading;
	using Console;

	internal class Program
	{
		private static void Main(string[] args)
		{
			//using (var updateManager = new UpdateManager(@"C:\SquirrelReleases"))
			//{
			//	var text = updateManager.CurrentlyInstalledVersion();
			//	var releaseEntry = await updateManager.UpdateApp();
			//	var newVersion = releaseEntry?.Version.ToString();
			//}

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