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
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

    public bool HasErrors => _propertyNameToErrorsDictionary.Any();
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public bool HasSubmitErrorMessage => !string.IsNullOrEmpty(SubmitErrorMessage);

    public IEnumerable GetErrors(string? propertyName)
    {
        return propertyName == null ? [] : _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, []);
    }

    public MakeReservationViewModel(HotelStore hotelStore,
        NavigationService<ReservationListingViewModel> navigationService)
    {
        SubmitCommand = new MakeReservationCommandAsync(this, hotelStore, navigationService);
        CancelCommand = new NavigateCommand<ReservationListingViewModel>(navigationService);
        _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
    }

    private string _username = string.Empty;

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
            
            ClearError(nameof(Username));
            if(!HasUsername)
            {
                AddError(nameof(Username), "Username cannot be empty.");
            }
            OnPropertyChanged(nameof(CanCreateReservation));
        }
    }

    private int _floorNumber;

    public int FloorNumber
    {
        get => _floorNumber;
        set
        {
            _floorNumber = value;
            OnPropertyChanged();
            
            ClearError(nameof(FloorNumber));
            if (!HasFloorNumberGreaterThanZero)
            {
                AddError(nameof(FloorNumber), "Floor number must be greater than zero.");
            }
            OnPropertyChanged(nameof(CanCreateReservation));
        }
    }

    private int _roomNumber;

    public int RoomNumber
    {
        get => _roomNumber;
        set
        {
            _roomNumber = value;
            OnPropertyChanged();
            
            ClearError(nameof(RoomNumber));
            if (!HasRoomNumberGreaterThanZero)
            {
                AddError(nameof(RoomNumber), "Room number must be greater than zero.");
            }
            OnPropertyChanged(nameof(CanCreateReservation));
        }
    }

    private DateTime _startDate = DateTime.Now;

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
                AddError(nameof(EndDate), "End date cannot be before Start date");
                AddError(nameof(StartDate), "Start date cannot be before end date");
            }
            OnPropertyChanged(nameof(CanCreateReservation));
        }
    }

    private DateTime _endDate = DateTime.Now.AddDays(7);

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
                AddError(nameof(StartDate), "Start date cannot be before end date");
                AddError(nameof(EndDate), "End date cannot be before Start date");
            }
            OnPropertyChanged(nameof(CanCreateReservation));
        }
    }

    private bool _isSubmitting;

    public bool IsSubmitting
    {
        get => _isSubmitting;
        set
        {
            _isSubmitting = value;
            OnPropertyChanged();
        }
    }

    private string _submitErrorMessage = string.Empty;

    public string SubmitErrorMessage
    {
        get => _submitErrorMessage;
        set
        {
            _submitErrorMessage = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasSubmitErrorMessage));
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

    public bool CanCreateReservation =>
        HasUsername &&
        HasFloorNumberGreaterThanZero &&
        HasRoomNumberGreaterThanZero &&
        HasStartDateBeforeEndDate &&
        !HasErrors;

    private bool HasUsername => !string.IsNullOrEmpty(Username);
    private bool HasFloorNumberGreaterThanZero => FloorNumber > 0;
    private bool HasRoomNumberGreaterThanZero => RoomNumber > 0;
    private bool HasStartDateBeforeEndDate => StartDate < EndDate;
}