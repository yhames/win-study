using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Stores;

namespace WpfTutorial.ViewModels;

public partial class ReservationListingViewModel : ObservableRecipient, IRecipient<ReservationAddedMessage>
{
    [ObservableProperty] private bool _isLoading;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(HasErrorMessage))]
    private string _errorMessage = string.Empty;

    private readonly HotelStore _hotelStore;
    private readonly NavigationService<MakeReservationViewModel> _navigationService;

    private readonly ObservableCollection<ReservationViewModel> _reservations = [];

    public ObservableCollection<ReservationViewModel> Reservations => _reservations;

    public bool HasReservations => _reservations.Any();

    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

    [RelayCommand]
    private void MakeReservation()
    {
        _navigationService.Navigate();
    }

    [RelayCommand]
    private async Task LoadReservations()
    {
        ErrorMessage = string.Empty;
        IsLoading = true;
        try
        {
            await _hotelStore.Load();
            UpdateReservations(_hotelStore.Reservations);
        }
        catch (Exception)
        {
            ErrorMessage = "Failed to load reservations.";
        }
        finally
        {
            IsLoading = false;
        }
    }

    private ReservationListingViewModel(HotelStore hotelStore,
        NavigationService<MakeReservationViewModel> navigationService)
    {
        _hotelStore = hotelStore;
        _navigationService = navigationService;
        _reservations.CollectionChanged += OnReservationsChanged;
    }

    protected override void OnActivated()
    {
        StrongReferenceMessenger.Default.RegisterAll(this);
        base.OnActivated();
    }

    protected override void OnDeactivated()
    {
        StrongReferenceMessenger.Default.UnregisterAll(this);
        base.OnDeactivated();
    }

    public void Receive(ReservationAddedMessage message)
    {
        var reservationViewModel = new ReservationViewModel(message.Value);
        Reservations.Add(reservationViewModel);
    }

    private void OnReservationsChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(HasReservations));
    }

    public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore,
        NavigationService<MakeReservationViewModel> navigationService)
    {
        var viewModel = new ReservationListingViewModel(hotelStore, navigationService);
        viewModel.LoadReservationsCommand.Execute(null);
        return viewModel;
    }

    public void UpdateReservations(IEnumerable<Reservation> reservations)
    {
        _reservations.Clear();
        foreach (var reservation in reservations)
        {
            var reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }
    }
}