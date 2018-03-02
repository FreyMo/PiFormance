namespace PiFormance.Server
{
	using System;

	internal class Program
	{
		private static void Main(string[] args)
		{
			using (new Server())
			{
				Console.ReadKey();
			}
		}
	}
}