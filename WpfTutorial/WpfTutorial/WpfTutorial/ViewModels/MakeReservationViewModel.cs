using System.Windows.Input;
using WpfTutorial.Commands;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Services.Impl;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.ViewModels;

public class MakeReservationViewModel : ViewModelBase
{
    private string _username = string.Empty;
    private int _floorNumber;
    private int _roomNumber;
    private DateTime _startDate = DateTime.Now;
    private DateTime _endDate = DateTime.Now.AddDays(7);

    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    public MakeReservationViewModel(Hotel hotel, INavigationService navigationService)
    {
        SubmitCommand = new MakeReservationCommand(this, hotel, navigationService);
        CancelCommand = new NavigateCommand(navigationService);
    }

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    public int FloorNumber
    {
        get => _floorNumber;
        set
        {
            _floorNumber = value;
            OnPropertyChanged();
        }
    }

    public int RoomNumber
    {
        get => _roomNumber;
        set
        {
            _roomNumber = value;
            OnPropertyChanged();
        }
    }

    public DateTime StartDate
    {
        get => _startDate;
        set
        {
            _startDate = value;
            OnPropertyChanged();
        }
    }

    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            _endDate = value;
            OnPropertyChanged();
        }
    }
}