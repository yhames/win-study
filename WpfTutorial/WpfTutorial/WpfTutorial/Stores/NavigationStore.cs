using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.Stores;

public class NavigationStore
{
    private ViewModelBase? _currentViewModel;

    public event Action? CurrentViewModelChanged;

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }
}