using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfTutorial.Stores;

public class NavigationStore
{
    private ObservableObject? _currentViewModel;

    public event Action? CurrentViewModelChanged;

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }

    public ObservableObject? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            if (_currentViewModel is ObservableRecipient recipient)
            {
                recipient.IsActive = false;
                _currentViewModel = value;
                recipient.IsActive = true;
            }
            else
            {
                _currentViewModel = value;
            }
            OnCurrentViewModelChanged();
        }
    }
}