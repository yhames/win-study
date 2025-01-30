using WpfTutorial.Commands.Base;

namespace WpfTutorial.Commands;

/**
 * RelayCommand는 CallbackCommand와 기능상 동일하지만 CommandBase를 상속한 클래스입니다.
 */
public class RelayCommand(Action callback, Func<bool>? canExecute = null) : CommandBase
{
    public override bool CanExecute(object? parameter)
    {
        return canExecute == null || canExecute();
    }

    public override void Execute(object? parameter)
    {
        callback.Invoke();
    }
}