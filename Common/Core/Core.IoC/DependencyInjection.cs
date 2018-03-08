namespace Core.IoC
{
	using Definitions.Container;

	public static class DependencyInjection
	{
		public static TContainer By<TContainer>() where TContainer : IIoCContainer, new()
		{
			return new TContainer();
		}
	}
}