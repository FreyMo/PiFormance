namespace Core.Standard.Messenger.Messenger
{
	using System;
	using System.Collections.Generic;
	using ArgumentMust;

	internal class Handlers : List<WeakReference>
	{
		public Handlers(WeakReference weakReference)
		{
			ArgumentMust.NotBeNull(() => weakReference);

			Add(weakReference);
		}
	}
}