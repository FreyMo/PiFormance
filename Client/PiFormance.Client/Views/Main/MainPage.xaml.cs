namespace PiFormance.Client.Views.Main
{
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Navigation;
	using Services;

	public sealed partial class MainPage : Page
	{
		private TouchInputService _touchInputService;

		public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			_touchInputService = new TouchInputService();
			await _touchInputService.InitializeAsync();

			base.OnNavigatedTo(e);
		}
	}
}