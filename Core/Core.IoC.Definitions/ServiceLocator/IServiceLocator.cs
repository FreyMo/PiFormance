namespace Core.IoC.Definitions.ServiceLocator
{
	using System;

	public interface IServiceLocator
	{
		T Resolve<T>();

		object ResolveType(Type type);
	}
}