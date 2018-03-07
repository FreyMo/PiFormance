namespace Core.Standard.Commands.AsyncCommand
{
	using System.ComponentModel;
	using System.Threading.Tasks;

	public interface IAsyncCommand : ICommandBase, INotifyPropertyChanged
	{
		bool IsRunning { get; }

		Task ExecuteAsync(object parameter);
	}
}