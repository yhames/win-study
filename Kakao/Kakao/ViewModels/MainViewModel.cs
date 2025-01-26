using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Kakao.ViewModels;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private INotifyPropertyChanged _currentViewModel;

    public MainViewModel()
    {
        _currentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(LoginViewModel))!;
    }

    [RelayCommand]
    public void ToLogin()
    {
        CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(LoginViewModel))!;
    }

    [RelayCommand]
    public void ToChangePassword()
    {
        CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(ChangePasswordViewModel))!;
    }

    [RelayCommand]
    public void ToSignUp()
    {
        CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(SignUpViewModel))!;
    }
}