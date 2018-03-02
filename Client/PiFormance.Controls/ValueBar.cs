namespace PiFormance.Controls
{
	using Windows.UI;
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls.Primitives;
	using Windows.UI.Xaml.Media;

	public sealed class ValueBar : RangeBase
	{
		public static readonly DependencyProperty BarColorProperty = DependencyProperty.Register(
			nameof(BarColor),
			typeof(SolidColorBrush),
			typeof(ValueBar),
			new PropertyMetadata(new SolidColorBrush(Colors.Aqua)));

		public static readonly DependencyProperty SeparatorColorProperty = DependencyProperty.Register(
			nameof(SeparatorColor),
			typeof(SolidColorBrush),
			typeof(ValueBar),
			new PropertyMetadata(new SolidColorBrush(Colors.Orange)));

		public ValueBar()
		{
			DefaultStyleKey = typeof(ValueBar);
		}

		public SolidColorBrush BarColor
		{
			get => (SolidColorBrush)GetValue(BarColorProperty);
			set => SetValue(BarColorProperty, value);
		}

		public SolidColorBrush SeparatorColor
		{
			get => (SolidColorBrush)GetValue(SeparatorColorProperty);
			set => SetValue(SeparatorColorProperty, value);
		}
	}
}