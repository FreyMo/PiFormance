namespace Core.Standard.Predicates
{
	using System;

	internal static class ComparablePredicates
	{
		public static bool IsEqualTo<T>(this T source, T target) where T : IComparable
		{
			return source.CompareTo(target) == 0;
		}

		public static bool IsLessThan<T>(this T source, T target) where T : IComparable
		{
			return source.CompareTo(target) < 0;
		}

		public static bool IsLessOrEqual<T>(this T source, T target) where T : IComparable
		{
			return source.IsLessThan(target) || source.IsEqualTo(target);
		}

		public static bool IsGreaterThan<T>(this T source, T target) where T : IComparable
		{
			return source.CompareTo(target) > 0;
		}

		public static bool IsGreaterOrEqual<T>(this T source, T target) where T : IComparable
		{
			return source.IsGreaterThan(target) || source.IsEqualTo(target);
		}

		public static bool IsInRangeIncluding<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
		{
			return source.IsLessOrEqual(upperLimit) && source.IsGreaterOrEqual(lowerLimit);
		}

		public static bool IsInRangeExcluding<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
		{
			return source.IsLessThan(upperLimit) && source.IsGreaterThan(lowerLimit);
		}

		public static bool IsOutOfRange<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
		{
			return !source.IsInRangeIncluding(lowerLimit, upperLimit);
		}
	}
}