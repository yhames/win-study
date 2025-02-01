using WpfTutorial.Commands.Base;
using WpfTutorial.Services;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.Commands;

public class NavigateCommand<TViewModel>(NavigationService<TViewModel> navigationService) : CommandBase
    where TViewModel : ViewModelBase
{
    public override void Execute(object? parameter)
    {
        navigationService.Navigate();
    }
}