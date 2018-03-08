namespace PiFormance.Controls
{
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using Windows.UI;
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls.Primitives;
	using Windows.UI.Xaml.Media;

	public sealed class ValueBar : RangeBase, INotifyPropertyChanged
	{
		public static readonly DependencyProperty BarColorProperty = DependencyProperty.Register(
			nameof(BarColor),
			typeof(SolidColorBrush),
			typeof(ValueBar),
			new PropertyMetadata(new SolidColorBrush(Colors.White)));

		public static readonly DependencyProperty BarBackgroundColorProperty = DependencyProperty.Register(
			nameof(BarBackgroundColor),
			typeof(SolidColorBrush),
			typeof(ValueBar),
			new PropertyMetadata(new SolidColorBrush(Colors.DimGray)));

		public static readonly DependencyProperty SeparatorColorProperty = DependencyProperty.Register(
			nameof(SeparatorColor),
			typeof(SolidColorBrush),
			typeof(ValueBar),
			new PropertyMetadata(new SolidColorBrush(Colors.Red)));

		public double Scale => Value / Maximum;

		public ValueBar()
		{
			DefaultStyleKey = typeof(ValueBar);
		}

		public SolidColorBrush BarColor
		{
			get => (SolidColorBrush)GetValue(BarColorProperty);
			set => SetValue(BarColorProperty, value);
		}

		public SolidColorBrush BarBackgroundColor
		{
			get => (SolidColorBrush)GetValue(BarBackgroundColorProperty);
			set => SetValue(BarBackgroundColorProperty, value);
		}

		public SolidColorBrush SeparatorColor
		{
			get => (SolidColorBrush)GetValue(SeparatorColorProperty);
			set => SetValue(SeparatorColorProperty, value);
		}

		protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
		{
			base.OnMinimumChanged(oldMinimum, newMinimum);

			EvaluateStretch();
		}

		protected override void OnMaximumChanged(double oldMinimum, double newMinimum)
		{
			base.OnMinimumChanged(oldMinimum, newMinimum);

			EvaluateStretch();
		}

		protected override void OnValueChanged(double oldMinimum, double newMinimum)
		{
			base.OnMinimumChanged(oldMinimum, newMinimum);

			EvaluateStretch();
		}

		private void EvaluateStretch()
		{
			OnPropertyChanged(nameof(Scale));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}