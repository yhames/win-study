using CommunityToolkit.Mvvm.Messaging.Messages;
using WpfTutorial.Models;

namespace WpfTutorial.Stores;

public class ReservationAddedMessage : ValueChangedMessage<Reservation>
{
    public ReservationAddedMessage(Reservation value) : base(value)
    {
    }
}