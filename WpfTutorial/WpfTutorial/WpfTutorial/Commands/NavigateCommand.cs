using WpfTutorial.Services;

namespace WpfTutorial.Commands;

public class NavigateCommand(NavigationService navigationService) : CommandBase
{
    private readonly NavigationService _navigationService = navigationService;

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate();
    }
}