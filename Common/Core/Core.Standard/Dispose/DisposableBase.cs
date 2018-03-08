namespace Core.Standard.Dispose
{
	using System;

	public abstract class DisposableBase : IDisposable
	{
		private bool _disposed;

		~DisposableBase()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					DisposeManagedResources();
				}

				DisposeUnmanagedResources();

				_disposed = true;
			}
		}

		protected abstract void DisposeManagedResources();

		protected virtual void DisposeUnmanagedResources()
		{
		}
	}
}