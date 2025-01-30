using System.Windows.Input;

namespace WpfTutorial.Commands.Base;

public abstract class AsyncCommandBase(Action<Exception>? onException = null) : ICommand
{
    private bool _isExecuting;

    private bool IsExecuting
    {
        get => _isExecuting;
        set
        {
            _isExecuting = value;
            OnCanExecuteChanged();
        }
    }

    public event EventHandler? CanExecuteChanged;

    protected void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool CanExecute(object? parameter)
    {
        return !IsExecuting && CanExecuteAsync(parameter);
    }

    public async void Execute(object? parameter)
    {
        try
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }
        catch (Exception e)
        {
            onException?.Invoke(e);
        }
        finally
        {
            IsExecuting = false;
        }
    }

    protected virtual bool CanExecuteAsync(object? parameter)
    {
        return true;
    }

    protected abstract Task ExecuteAsync(object? parameter);
}