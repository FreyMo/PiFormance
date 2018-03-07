namespace Core.Standard.Commands.SyncCommand
{
	using System;
	using ArgumentMust;

	public class SyncCommand : SyncCommandBase
	{
		private readonly Action _executionAction;
		private readonly Func<bool> _canExecuteFunc;

		public SyncCommand(Action executionAction) : this(executionAction, () => true)
		{
		}

		public SyncCommand(Action executionAction, Func<bool> canExecuteFunc)
		{
			ArgumentMust.NotBeNull(() => executionAction);
			ArgumentMust.NotBeNull(() => canExecuteFunc);

			_executionAction = executionAction;
			_canExecuteFunc = canExecuteFunc;
		}
		
		public override bool CanExecute(object parameter)
		{
			return _canExecuteFunc();
		}

		public override void Execute(object parameter)
		{
			_executionAction();
		}
	}
}