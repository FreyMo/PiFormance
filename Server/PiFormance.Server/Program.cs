namespace PiFormance.Server
{
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

			if (false)
			{
				new ConsolePresenter(new ConsoleNativeMethods()).ShowConsole();
			}

			AutostartProvider.RunOnWindowsStartup();

			using (var server = new Server())
			{
				server.Run();
			}
		}
	}
}