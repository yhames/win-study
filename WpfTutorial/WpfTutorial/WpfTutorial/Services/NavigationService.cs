using System.Windows.Navigation;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels;

namespace WpfTutorial.Services;

public class NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
{
    public void Navigate()
    {
        navigationStore.CurrentViewModel = createViewModel();
    }
}