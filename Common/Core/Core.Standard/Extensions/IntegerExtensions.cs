namespace Core.Standard.Extensions
{
	using System;
	using System.Collections.Generic;
	using ArgumentMust;

	public static class IntegerExtensions
	{
		public static void Times(this int source, Action action)
		{
			ArgumentMust.NotBeNull(() => action);

			source.Times(i => action());
		}

		public static void Times(this int source, Action<int> action)
		{
			ArgumentMust.NotBeNull(() => action);

			source.Times(action, 0);
		}

		public static void Times(this int source, Action<int> action, int startIndex)
		{
			ArgumentMust.NotBeNull(() => action);

			for (var i = startIndex; i.IsLessThan(source + startIndex); i++)
			{
				action(i);
			}
		}

		public static IEnumerable<T> Times<T>(this int source, Func<T> func)
		{
			ArgumentMust.NotBeNull(() => func);

			return source.Times(i => func(), 0);
		}

		public static IEnumerable<T> Times<T>(this int source, Func<int, T> func)
		{
			ArgumentMust.NotBeNull(() => func);

			return source.Times(func, 0);
		}

		public static IEnumerable<T> Times<T>(this int source, Func<int, T> func, int startIndex)
		{
			ArgumentMust.NotBeNull(() => func);

			for (var i = startIndex; i.IsLessThan(source + startIndex); i++)
			{
				yield return func(i);
			}
		}
	}
}