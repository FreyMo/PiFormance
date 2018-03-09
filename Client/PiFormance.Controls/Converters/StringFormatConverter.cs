namespace PiFormance.Controls.Converters
{
	using System;
	using Windows.UI.Xaml.Data;
	using Core.Standard.Extensions;

	public class StringFormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var format = parameter.As<string>();

			return !string.IsNullOrEmpty(format) ? string.Format(format, value) : value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}