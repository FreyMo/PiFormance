namespace PiFormance.Server.Functional
{
	using System;
	using System.Deployment.Application;
	using Core.Standard.Extensions;
	using Microsoft.Win32;

	public static class AutostartProvider
	{
		private static readonly string StartPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) +
		                                           @"\Moritz\PiFormance\PiFormance.Server.appref-ms";

		private static readonly RegistryKey AppKey = Registry.CurrentUser.OpenSubKey(
			@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
			true);

		public static void RunOnWindowsStartup()
		{
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				//if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
				//{
					if (AppKey.GetValue("PiFormance.Server").Cast<string>() != StartPath)
					{
						AppKey.SetValue("PiFormance.Server", StartPath);
					}
				//}
			}
		}
	}
}