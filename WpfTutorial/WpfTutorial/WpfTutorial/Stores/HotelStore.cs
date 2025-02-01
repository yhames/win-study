using WpfTutorial.Models;
using WpfTutorial.ViewModels;

namespace WpfTutorial.Stores;

/**
 * Store 계층은 다음과 같은 책임을 가집니다.
 * 1. Lazy Initializing
 * 2. Manage application data in a centralized location
 * 3. Supporting reactivity on the UI
 */
public class HotelStore
{
    private readonly Hotel _hotel;
    private readonly List<Reservation> _reservations;
    private Lazy<Task> _initializeLazy;
    public IEnumerable<Reservation> Reservations => _reservations;
    
    public event Action<Reservation>? ReservationAdded;

    public HotelStore(Hotel hotel)
    {
        _hotel = hotel;
        _initializeLazy = new Lazy<Task>(Initialize);
        _reservations = [];
    }

    public async Task Load()
    {
        try
        {
            await _initializeLazy.Value;
        }
        catch (Exception)
        {
            _initializeLazy = new Lazy<Task>(Initialize);
            throw;
        }
    }

    public async Task MakeReservation(Reservation reservation)
    {
        await _hotel.MakeReservation(reservation);
        _reservations.Add(reservation);
        OnReservationAdded(reservation);
    }

    private void OnReservationAdded(Reservation reservation)
    {
        ReservationAdded?.Invoke(reservation);
    }

    private async Task Initialize()
    {
        var reservations = await _hotel.GetAllReservations();
        _reservations.Clear();
        _reservations.AddRange(reservations);
        // throw new Exception();
    }
}