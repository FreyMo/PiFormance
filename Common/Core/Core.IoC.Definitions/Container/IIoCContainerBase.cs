namespace Core.IoC.Definitions.Container
{
	using System.Collections.Generic;
	using System.Reflection;
	using Module;

	public interface IIoCContainerBase
	{
		void Load(IIoCModule module);

		void Load(IEnumerable<IIoCModule> modules);

		void Load(IEnumerable<Assembly> assemblies);
	}
}