namespace PiFormance.Client.Views.Settings
{
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Input;

	public sealed partial class SettingsView : UserControl
	{
		public SettingsView()
		{
			InitializeComponent();
		}

		private void ServerNameTextBox_OnKeyDown(object sender, KeyRoutedEventArgs e)
		{
			if (e.Key == Windows.System.VirtualKey.Enter)
			{
				if (FocusManager.GetFocusedElement() == ServerNameTextBox)
				{
					var isTabStop = ServerNameTextBox.IsTabStop;
					ServerNameTextBox.IsTabStop = false;
					ServerNameTextBox.IsEnabled = false;
					ServerNameTextBox.IsEnabled = true;
					ServerNameTextBox.IsTabStop = isTabStop;

					ServerNameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

					ApplyButton.Command?.Execute(null);

					e.Handled = true;
				}
			}
		}
	}
}