using WpfTutorial.Stores;
using WpfTutorial.ViewModels;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.Services.Impl;

public class NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
    : INavigationService
{
    public void Navigate()
    {
        navigationStore.CurrentViewModel = createViewModel();
    }
}