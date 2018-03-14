namespace PiFormance.Server
{
	using System;
	using System.Deployment.Application;
	using Core.Standard.Extensions;
	using Microsoft.Win32;

	public static class AutostartProvider
	{
		//private const string TaskName = "PiFormance";

		private static readonly string StartPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs)
		                   + @"\Moritz\PiFormance\PiFormance.Server.appref-ms";

		//private static readonly string StartPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) +
		//										   @"\" +
		//                                           System.Security.Principal.WindowsIdentity.GetCurrent().Name +
		//										   @"\PiFormance\PiFormance.Server.appref-ms";

		private static readonly RegistryKey AppKey = Registry.CurrentUser.OpenSubKey(
			@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
			true);

		public static void RunOnWindowsStartup()
		{
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
				{
					if (AppKey.GetValue("PiFormance.Server").Cast<string>() != StartPath)
					{
						AppKey.SetValue("PiFormance.Server", StartPath);
					}
				}
			}
				
			//var taskService = TaskService.Instance;

			//if (taskService.RootFolder.EnumerateTasks().Any(x => x.Name == TaskName))
			//{
			//	return;
			//}

			//var taskDefinition = taskService.NewTask();

			//taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;
			//taskDefinition.Triggers.Add(new LogonTrigger());
			//taskDefinition.Actions.Add(new ExecAction(StartPath));

			//taskService.RootFolder.RegisterTaskDefinition(TaskName, taskDefinition);

		}
	}
}