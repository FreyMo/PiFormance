namespace PiFormance.Server
{
	using System;
	using System.Deployment.Application;
	using Microsoft.Win32;

	public class AutostartProvider
	{
		private readonly string _startPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) +
		                           @"\Moritz\PiFormance\PiFormance.Server.appref-ms";

		private readonly RegistryKey _appKey = Registry.CurrentUser.OpenSubKey(
			@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
			true);

		public void RunOnWindowsStartup()
		{
			try
			{
				if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
				{
					_appKey.SetValue("PiFormance.Server", _startPath);
				}
			}
			catch (InvalidDeploymentException)
			{
				System.Console.WriteLine("Not deployed!");
			}
		}
	}
}