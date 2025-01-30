using System.Windows.Input;
using WpfTutorial.Commands.Base;

namespace WpfTutorial.Commands;

public class RelayCommandAsync(
    Func<Task> callback,
    Func<bool>? canExecute = null,
    Action<Exception>? onException = null)
    : AsyncCommandBase(onException: onException)
{
    protected override bool CanExecuteAsync(object? parameter)
    {
        return canExecute == null || canExecute();
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        await callback();
    }
}