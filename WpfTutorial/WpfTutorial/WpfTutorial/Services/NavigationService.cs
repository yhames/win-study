using WpfTutorial.Stores;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.Services;

public class NavigationService<TViewModel>(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    where TViewModel : ViewModelBase
{
    public void Navigate()
    {
        navigationStore.CurrentViewModel = createViewModel();
    }
}