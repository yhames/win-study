using System.Windows.Input;

namespace WpfTutorial.Commands;

/**
 * 간단한 Command의 경우 CallbackCommand를 사용해서 작성할 수 있다.
 * 하지만 복잡한 로직이나 ViewModel의 값이 필요한 경우에는 ClassCommand를 사용해는 것이 좋다.
 */
public class CallbackCommand(Action callback, Func<bool>? canExecute = null) : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        if (canExecute == null)
        {
            return true;
        }

        return canExecute();
    }

    public void Execute(object? parameter)
    {
        callback?.Invoke();
    }
}