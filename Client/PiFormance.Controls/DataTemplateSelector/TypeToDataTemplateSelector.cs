namespace SLaM.View.DataTemplateSelector
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows;
	using System.Windows.Controls;

	public class TypeToDataTemplateSelector : DataTemplateSelector
	{
		public List<TypeToDataTemplate> TypeToDataTemplates { get; set; } = new List<TypeToDataTemplate>();

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item == null)
			{
				return new DataTemplate();
			}

			var type = item.GetType();
			return TypeToDataTemplates.FirstOrDefault(t => t.Type == type || t.Type.IsAssignableFrom(type))?.DataTemplate;
		}
	}
}