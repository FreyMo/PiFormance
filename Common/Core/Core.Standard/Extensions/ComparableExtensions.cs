namespace Core.Standard.Extensions
{
	using System;
	using ArgumentMust;
	using Predicates;

	public static class ComparableExtensions
	{
		public static bool IsEqualTo<T>(this T first, T second) where T : struct, IComparable
		{
			return ComparablePredicates.IsEqualTo(first, second);
		}

		public static bool IsLessThan<T>(this T first, T second) where T : struct, IComparable
		{
			return ComparablePredicates.IsLessThan(first, second);
		}

		public static bool IsLessOrEqual<T>(this T first, T second) where T : struct, IComparable
		{
			return ComparablePredicates.IsLessOrEqual(first, second);
		}

		public static bool IsGreaterThan<T>(this T first, T second) where T : struct, IComparable
		{
			return ComparablePredicates.IsGreaterThan(first, second);
		}

		public static bool IsGreaterOrEqual<T>(this T first, T second) where T : struct, IComparable
		{
			return ComparablePredicates.IsGreaterOrEqual(first, second);
		}

		public static bool IsInRangeIncluding<T>(this T first, T lowerLimit, T upperLimit) where T : struct, IComparable
		{
			ArgumentMust.BeGreaterOrEqual(() => upperLimit, lowerLimit);

			return ComparablePredicates.IsInRangeIncluding(first, lowerLimit, upperLimit);
		}

		public static bool IsInRangeExcluding<T>(this T first, T lowerLimit, T upperLimit) where T : struct, IComparable
		{
			ArgumentMust.BeGreater(() => upperLimit, lowerLimit);
			
			return ComparablePredicates.IsInRangeExcluding(first, lowerLimit, upperLimit);
		}

		public static bool IsOutOfRange<T>(this T first, T lowerLimit, T upperLimit) where T : struct, IComparable
		{
			ArgumentMust.BeGreaterOrEqual(() => upperLimit, lowerLimit);

			return ComparablePredicates.IsOutOfRange(first, lowerLimit, upperLimit);
		}
	}
}
