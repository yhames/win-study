using System.Windows.Input;

namespace WpfTutorial.Commands.Base;

public abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged;

    /**
     * false인 경우 버튼이 Disabled 됩니다.
     * CanExecuteChanged가 Trigger되면 해당 함수가 실행되면서
     * CanExecute의 상태가 적절히 변경됩니다.
     */
    public virtual bool CanExecute(object? parameter)
    {
        return true;
    }

    /**
     * 버튼을 Click 했을 떄 실행되는 함수입니다.
     */
    public abstract void Execute(object? parameter);
    
    /**
     * CanExecuteChanged를 실행하기 위한 Helper 함수입니다.
     */
    protected void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    } 
}