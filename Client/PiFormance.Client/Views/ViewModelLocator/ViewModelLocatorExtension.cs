namespace PiFormance.Client.Views.ViewModelLocator
{
	using Windows.UI.Xaml.Markup;
	using Core.IoC.Definitions.ServiceLocator;
	using ViewModels.Base;

	public class ServiceLocatorExtension<TViewModelType> : MarkupExtension
		where TViewModelType : class, IViewModel
	{
		protected override object ProvideValue()
		{
			return ServiceLocator.Instance.ResolveType(typeof(TViewModelType));
		}
	}
}