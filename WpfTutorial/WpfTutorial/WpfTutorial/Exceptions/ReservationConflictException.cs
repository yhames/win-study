using System.Runtime.Serialization;
using WpfTutorial.Models;

namespace WpfTutorial.Exceptions;

public class ReservationConflictException : Exception
{
    public Reservation Existing { get; }
    public Reservation Incoming { get; }

    public ReservationConflictException(Reservation existing, Reservation incoming)
    {
        Existing = existing;
        Incoming = incoming;
    }

    public ReservationConflictException(string? message, Reservation existing, Reservation incoming) : base(message)
    {
        Existing = existing;
        Incoming = incoming;
    }

    public ReservationConflictException(string? message, Exception? innerException, Reservation existing,
        Reservation incoming) : base(message, innerException)
    {
        Existing = existing;
        Incoming = incoming;
    }
}