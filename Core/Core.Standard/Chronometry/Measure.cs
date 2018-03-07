namespace Core.Standard.Chronometry
{
	using System;
	using System.Diagnostics;

	public static class Measure
	{
		public static void Time(Action action)
		{
			ArgumentMust.ArgumentMust.NotBeNull(() => action);

			var stopWatch = Stopwatch.StartNew();

			action();

			stopWatch.Stop();
			Debug.WriteLine($"It took {stopWatch.Elapsed.TotalMilliseconds} ms to finish the action called from {action.Target}.");
		}

		public static TResult Time<TResult>(Func<TResult> func)
		{
			ArgumentMust.ArgumentMust.NotBeNull(() => func);

			var stopWatch = Stopwatch.StartNew();

			var result = func();

			stopWatch.Stop();
			Debug.WriteLine($"It took {stopWatch.Elapsed.TotalMilliseconds} ms to finish the action called from {func.Target}.");

			return result;
		}
	}
}