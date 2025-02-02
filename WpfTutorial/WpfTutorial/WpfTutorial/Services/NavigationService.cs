using CommunityToolkit.Mvvm.ComponentModel;
using WpfTutorial.Stores;

namespace WpfTutorial.Services;

public class NavigationService<TViewModel>(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    where TViewModel : ObservableObject
{
    public void Navigate()
    {
        navigationStore.CurrentViewModel = createViewModel();
    }
}