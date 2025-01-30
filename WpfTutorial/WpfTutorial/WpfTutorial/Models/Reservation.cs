﻿using WpfTutorial.Dtos;

namespace WpfTutorial.Models;

public class Reservation
{
    public RoomId RoomId { get; }
    public string Username { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }

    public TimeSpan Length => EndDate.Subtract(StartDate);

    public Reservation(RoomId roomId, string username, DateTime startDate, DateTime endDate)
    {
        RoomId = roomId;
        Username = username;
        StartDate = startDate;
        EndDate = endDate;
    }
}