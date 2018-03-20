namespace PiFormance.Client.Views.Settings
{
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Input;
	using Core.Standard.Extensions;
	using ViewModels.Settings;

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
				ServerNameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

				// DIRTY HACK
				//var viewModel = ServerNameTextBox.GetBindingExpression(TextBox.TextProperty)?.ParentBinding.Source.As<SettingsViewModel>();
				//if (viewModel != null)
				//{
				//	viewModel.ServerName = ServerNameTextBox.Text;
				//}

				ApplyButton?.Command?.Execute(null);

				e.Handled = true;
			}
		}
	}
}