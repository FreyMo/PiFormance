namespace Core.Standard.Commands.SyncCommand
{
	using System;

	public abstract class SyncCommandBase : ISyncCommand
	{
		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		public abstract bool CanExecute(object parameter);

		public abstract void Execute(object parameter);
	}
}