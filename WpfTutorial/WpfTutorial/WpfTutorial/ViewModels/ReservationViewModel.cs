using WpfTutorial.Models;
using WpfTutorial.ViewModels.Base;

namespace WpfTutorial.ViewModels;

public class ReservationViewModel(Reservation reservation) : ViewModelBase
{
    public string RoomId => reservation.RoomId.ToString();
    public string Username => reservation.Username;
    public string StartDate => reservation.StartDate.ToString("d");
    public string EndDate => reservation.EndDate.ToString("d");
}