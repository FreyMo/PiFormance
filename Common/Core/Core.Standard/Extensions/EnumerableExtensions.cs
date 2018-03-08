namespace Core.Standard.Extensions
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using ArgumentMust;
	using Predicates;

	public static class EnumerableExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			ArgumentMust.NotBeNull(() => source);
			ArgumentMust.NotBeNull(() => action);

			foreach (var item in source)
			{
				action(item);
			}
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action action)
		{
			ArgumentMust.NotBeNull(() => source);
			ArgumentMust.NotBeNull(() => action);

			foreach (var item in source)
			{
				action();
			}
		}

		public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			ArgumentMust.NotBeNull(() => source);
			ArgumentMust.NotBeNull(() => predicate);

			return EnumerablePredicates.None(source, predicate);
		}

		public static bool IsEmpty<T>(this IEnumerable<T> source)
		{
			ArgumentMust.NotBeNull(() => source);

			return EnumerablePredicates.IsEmpty(source);
		}

		public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> source)
		{
			ArgumentMust.NotBeNull(() => source);

			return new ObservableCollection<T>(source);
		}

		public static ReadOnlyObservableCollection<T> ToReadOnlyObservableCollection<T>(this ObservableCollection<T> source)
		{
			ArgumentMust.NotBeNull(() => source);

			return new ReadOnlyObservableCollection<T>(source);
		}

		public static TSource SingleOfType<TSource>(this IEnumerable source)
		{
			ArgumentMust.NotBeNull(() => source);

			return source.OfType<TSource>().Single();
		}

		public static TSource SingleOfType<TSource>(this IEnumerable source, Func<TSource, bool> predicate)
		{
			ArgumentMust.NotBeNull(() => source);
			ArgumentMust.NotBeNull(() => predicate);

			return source.OfType<TSource>().Single(predicate);
		}

		public static TSource FirstOfType<TSource>(this IEnumerable source)
		{
			ArgumentMust.NotBeNull(() => source);

			return source.OfType<TSource>().First();
		}
	}
}