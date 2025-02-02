using System.ComponentModel.DataAnnotations;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfTutorial.Exceptions;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Stores;

namespace WpfTutorial.ViewModels;

public partial class MakeReservationViewModel(
    HotelStore hotelStore,
    NavigationService<ReservationListingViewModel> navigationService)
    : ObservableValidator
{
    public bool HasSubmitErrorMessage => !string.IsNullOrEmpty(SubmitErrorMessage);


    [RelayCommand(CanExecute = nameof(CanCreateReservation))]
    private async Task Submit()
    {
        SubmitErrorMessage = string.Empty;
        IsSubmitting = true;
        var roomId = new RoomId(FloorNumber, RoomNumber);
        var reservation = new Reservation(roomId, Username, StartDate, EndDate);
        try
        {
            await hotelStore.MakeReservation(reservation);
            MessageBox.Show("Reservation added successfully", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            navigationService.Navigate();
        }
        catch (ReservationConflictException)
        {
            SubmitErrorMessage = "This room is already taken on those dates.";
        }
        catch (InvalidReservationTimeRangeException)
        {
            SubmitErrorMessage = "Start date must be before end date.";
        }
        catch (Exception)
        {
            SubmitErrorMessage = "Failed to make reservation.";
        }
        finally
        {
            IsSubmitting = false;
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        navigationService.Navigate();
    }

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [CustomValidation(typeof(MakeReservationViewModel), nameof(ValidateEmptyOrBlank),
        ErrorMessage = "Username cannot be blank.")]
    [NotifyPropertyChangedFor(nameof(CanCreateReservation))]
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private string _username = string.Empty;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Range(1, int.MaxValue, ErrorMessage = "FloorNumber must be greater than 0")]
    [NotifyPropertyChangedFor(nameof(CanCreateReservation))]
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private int _floorNumber = 1;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Range(0, int.MaxValue, ErrorMessage = "RoomNumber must be greater than 0")]
    [NotifyPropertyChangedFor(nameof(CanCreateReservation))]
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private int _roomNumber;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [CustomValidation(typeof(MakeReservationViewModel), nameof(ValidateStartDateBeforeEndDate),
        ErrorMessage = "Start date cannot be after end date")]
    [NotifyPropertyChangedFor(nameof(CanCreateReservation))]
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private DateTime _startDate = DateTime.Now;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [CustomValidation(typeof(MakeReservationViewModel), nameof(ValidateStartDateBeforeEndDate),
        ErrorMessage = "End date cannot be before start date")]
    [NotifyPropertyChangedFor(nameof(CanCreateReservation))]
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private DateTime _endDate = DateTime.Now.AddDays(7);

    partial void OnStartDateChanged(DateTime value)
    {
        ValidateProperty(EndDate, nameof(EndDate));
    }
    
    partial void OnEndDateChanged(DateTime value)
    {
        ValidateProperty(StartDate, nameof(StartDate));
    }

    public static ValidationResult ValidateStartDateBeforeEndDate(string name, ValidationContext context)
    {
        var viewModel = (MakeReservationViewModel)context.ObjectInstance;
        if (viewModel.StartDate > viewModel.EndDate)
        {
            return new ValidationResult("Start date cannot be after end date");
        }
        return ValidationResult.Success!;
    }

    public static ValidationResult ValidateEmptyOrBlank(string name, ValidationContext context)
    {
        var viewModel = (MakeReservationViewModel)context.ObjectInstance;
        if (string.IsNullOrEmpty(viewModel.Username) || string.IsNullOrWhiteSpace(viewModel.Username))
        {
            return new ValidationResult("Username cannot be blank.");
        }

        return ValidationResult.Success!;
    }

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(CanCreateReservation))]
    private bool _isSubmitting;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(HasSubmitErrorMessage))]
    private string _submitErrorMessage = string.Empty;

    public bool CanCreateReservation =>
        HasUsername &&
        HasFloorNumberGreaterThanZero &&
        HasRoomNumberGreaterThanZero &&
        HasStartDateBeforeEndDate &&
        !HasErrors;

    private bool HasUsername => !string.IsNullOrEmpty(Username);
    private bool HasFloorNumberGreaterThanZero => FloorNumber > 0;
    private bool HasRoomNumberGreaterThanZero => RoomNumber >= 0;
    private bool HasStartDateBeforeEndDate => StartDate < EndDate;
}