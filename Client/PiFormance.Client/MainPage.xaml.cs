namespace PiFormance.Client
{
	using Windows.UI.Xaml.Controls;

	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
			DataContext = new MainPageViewModel();
		}
	}
}