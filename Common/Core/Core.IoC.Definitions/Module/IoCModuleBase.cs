namespace Core.IoC.Definitions.Module
{
	using Container;
	using Standard.ArgumentMust;

	public abstract class IoCModuleBase : IIoCModule
	{
		private bool _isLoaded;

		protected IIoCContainer Container { get; }

		protected IoCModuleBase(IIoCContainer container)
		{
			ArgumentMust.NotBeNull(() => container);

			Container = container;
		}

		public void Load()
		{
			if (!_isLoaded)
			{
				_isLoaded = true;
				LoadInternal();
			}
		}

		protected abstract void LoadInternal();
	}
}