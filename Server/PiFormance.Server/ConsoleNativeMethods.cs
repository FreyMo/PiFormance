namespace PiFormance.Server
{
	using System;
	using System.Runtime.InteropServices;

	public class ConsoleNativeMethods
	{
		[DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr GetStdHandle(int nStdHandle);

		[DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		private static extern int AllocConsole();

		public IntPtr GetStandardHandle(int stdHandle)
		{
			return GetStdHandle(stdHandle);
		}

		public void AllocateConsole()
		{
			AllocConsole();
		}
	}
}