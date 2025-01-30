namespace WpfTutorial.Commands.Base;

public abstract class AsyncCommandBase : CommandBase
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

    public override bool CanExecute(object? parameter)
    {
        return !IsExecuting && base.CanExecute(parameter);
    }

    public override async void Execute(object? parameter)
    {
        try
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }
        catch (Exception)
        {
            // ignored
        }
        finally
        {
            IsExecuting = false;
        }
    }

    protected abstract Task ExecuteAsync(object? parameter);
}