namespace PiFormance.Server
{
	using System;
	using Core.Standard.Extensions;
	using Microsoft.Win32;

	public static class AutostartProvider
	{
		// TODO: NEEDS TO BE CHANGED TO DEPLOYMENT PATH
		private static readonly string StartPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) +
		                                           @"\Moritz\PiFormance\PiFormance.Server.appref-ms";

		private static readonly RegistryKey AppKey = Registry.CurrentUser.OpenSubKey(
			@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
			true);

		public static void RunOnWindowsStartup()
		{
			if (AppKey.GetValue("PiFormance.Server").Cast<string>() != StartPath)
			{
				AppKey.SetValue("PiFormance.Server", StartPath);
			}
		}
	}
}