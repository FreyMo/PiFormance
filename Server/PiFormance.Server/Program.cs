namespace PiFormance.Server
{
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Security.Principal;
	using System.Threading;
	using Console;

	internal class Program
	{
		private static void Main(string[] args)
		{
			if (!IsRunAsAdministrator())
			{
				var test = Process.GetCurrentProcess().ProcessName;

				ProcessStartInfo proc = new ProcessStartInfo
				{
					UseShellExecute = true,
					WorkingDirectory = Environment.CurrentDirectory,
					Verb = "runas"
				};
				proc.FileName = Path.Combine(proc.WorkingDirectory, test) + ".exe";

				try
				{
					Process.Start(proc);
				}
				catch (Exception)
				{
				}

				Environment.Exit(1);
			}

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

		private static bool IsRunAsAdministrator()
		{
			var wi = WindowsIdentity.GetCurrent();
			var wp = new WindowsPrincipal(wi);

			return wp.IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}