namespace PiFormance.Server.Functional
{
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Security.Principal;

	internal class AdminElevator
	{
		public static void EnsureAdminRights()
		{
			if (!IsRunAsAdministrator())
			{
				var processName = Process.GetCurrentProcess().ProcessName;

				var processStartInfo = new ProcessStartInfo
				{
					UseShellExecute = true,
					WorkingDirectory = Environment.CurrentDirectory,
					Verb = "runas"
				};
				processStartInfo.FileName = Path.Combine(processStartInfo.WorkingDirectory, processName) + ".exe";

				Process.Start(processStartInfo);

				Environment.Exit(0);
			}
		}

		private static bool IsRunAsAdministrator()
		{
			var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}