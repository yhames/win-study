using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using WpfTutorial.Commands;
using WpfTutorial.Services;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.ViewModels;

public class MakeReservationViewModel : ViewModelBase, INotifyDataErrorInfo
{
    private string _username = string.Empty;
    private int _floorNumber;
    private int _roomNumber;
    private DateTime _startDate = DateTime.Now;
    private DateTime _endDate = DateTime.Now.AddDays(7);

    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

    public bool HasErrors => _propertyNameToErrorsDictionary.Any();
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        return propertyName == null ? [] : _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, []);
    }

    public MakeReservationViewModel(HotelStore hotelStore, NavigationService<ReservationListingViewModel> navigationService)
    {
        SubmitCommand = new MakeReservationCommandAsync(this, hotelStore, navigationService);
        CancelCommand = new NavigateCommand<ReservationListingViewModel>(navigationService);
        _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
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

            ClearError(nameof(StartDate));
            ClearError(nameof(EndDate));
            if (EndDate < StartDate)
            {
                AddError(nameof(StartDate), "Start date cannot be before end date");
            }
        }
    }

    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            _endDate = value;
            OnPropertyChanged();

            ClearError(nameof(StartDate));
            ClearError(nameof(EndDate));
            if (EndDate < StartDate)
            {
                AddError(nameof(EndDate), "End date cannot be before Start date");
            }
        }
    }

    private void ClearError(string propertyName)
    {
        _propertyNameToErrorsDictionary.Remove(propertyName);
        OnErrorsChanged(propertyName);
    }

    private void AddError(string propertyName, string errorMessage)
    {
        if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
        {
            _propertyNameToErrorsDictionary.Add(propertyName, []);
        }

        _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);
        OnErrorsChanged(propertyName);
    }

    private void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}