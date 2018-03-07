namespace Core.Standard.Extensions
{
	using System.Collections.Generic;

	public static class GenericExtensions
	{
		public static IEnumerable<T> ToEnumerable<T>(this T source)
		{
			yield return source;
		}

		public static bool EqualityEquals<T>(this T source, T target)
		{
			return EqualityComparer<T>.Default.Equals(source, target);
		}
	}
}