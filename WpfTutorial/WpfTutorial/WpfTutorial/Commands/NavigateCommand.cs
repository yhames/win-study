using WpfTutorial.Commands.Base;
using WpfTutorial.Services;

namespace WpfTutorial.Commands;

public class NavigateCommand(INavigationService navigationService) : CommandBase
{
    public override void Execute(object? parameter)
    {
        navigationService.Navigate();
    }
}