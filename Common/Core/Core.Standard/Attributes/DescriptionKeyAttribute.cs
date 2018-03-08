namespace Core.Standard.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
	public class DescriptionKeyAttribute : Attribute
	{
		public string Key { get; }

		public DescriptionKeyAttribute(string key)
		{
			Key = key;
		}
	}
}