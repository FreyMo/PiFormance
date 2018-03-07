namespace Core.Standard.Extensions
{
	using System.Collections.Generic;
	using ArgumentMust;

	public static class CollectionExtensions
	{
		public static void AddOnce<T>(this ICollection<T> source, T itemToAdd)
		{
			ArgumentMust.NotBeNull(() => source);

			if (!source.Contains(itemToAdd))
			{
				source.Add(itemToAdd);
			}
		}

		public static void RemoveAll<T>(this ICollection<T> source, T itemToRemove)
		{
			ArgumentMust.NotBeNull(() => source);

			while (source.Contains(itemToRemove))
			{
				source.Remove(itemToRemove);
			}
		}
	}
}