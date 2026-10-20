namespace CinemaTicketBooking.Extensions;

using CinemaTicketBooking.Models;

public static class CinemaExtensions
{
    public static string GetBookingStatus(
        this Booking booking,
        DateTime showDate)
    {
        if (booking.CancellationDate.HasValue)
        {
            return "Cancelled";
        }

        DateTime today = DateTime.Today;

        if (showDate.Date < today)
        {
            return "Completed";
        }

        if (showDate.Date == today)
        {
            return "Today";
        }

        return "Upcoming";
    }

    public static decimal CalculateTotalAmount(
        this Booking booking,
        decimal ticketPrice)
    {
        return booking.NumberOfTickets * ticketPrice;
    }
}