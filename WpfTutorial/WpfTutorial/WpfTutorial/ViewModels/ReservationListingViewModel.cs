﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfTutorial.Commands;
using WpfTutorial.Models;
using WpfTutorial.Services;
using WpfTutorial.Stores;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.ViewModels;

public class ReservationListingViewModel : ViewModelBase
{
    private readonly HotelStore _hotelStore;
    private readonly ObservableCollection<ReservationViewModel> _reservations = [];
    public ObservableCollection<ReservationViewModel> Reservations => _reservations;

    public bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand LoadReservationsCommand { get; }
    public ICommand MakeReservationCommand { get; }

    private ReservationListingViewModel(HotelStore hotelStore, INavigationService navigationService)
    {
        _hotelStore = hotelStore;
        MakeReservationCommand = new NavigateCommand(navigationService);
        LoadReservationsCommand = new LoadReservationsCommandAsync(hotelStore, this);
        _hotelStore.ReservationAdded += OnReservationAdded;
    }

    public override void Dispose()
    {
        _hotelStore.ReservationAdded -= OnReservationAdded;
        base.Dispose();
    }

    private void OnReservationAdded(Reservation reservation)
    {
        var reservationViewModel = new ReservationViewModel(reservation);
        Reservations.Add(reservationViewModel);
    }

    public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, INavigationService navigationService)
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