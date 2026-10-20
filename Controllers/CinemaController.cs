using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Controllers;

public class CinemaController : Controller
{
    private static List<Movie> movies = new List<Movie>
    {
        new Movie
        {
            MovieId = 1,
            MovieName = "Bahubali:The Beginning",
            Genre = "Action",
            Language = "Hindi",
            TicketPrice = 250,
            AvailableSeats = 100
        },

        new Movie
        {
            MovieId = 2,
            MovieName = "Pushpa",
            Genre = "Action",
            Language = "Telugu",
            TicketPrice = 200,
            AvailableSeats = 80
        },

        new Movie
        {
            MovieId = 3,
            MovieName = "Dhammal",
            Genre = "Comedy",
            Language = "Hindi",
            TicketPrice = 180,
            AvailableSeats = 70
        }
    };

    private static List<Booking> bookings = new List<Booking>();

    public IActionResult Index()
    {
        return View(bookings);
    }

    [HttpGet]
    public IActionResult BookTicket()
    {
        return View();
    }

    [HttpPost]
    public IActionResult BookTicket(Booking booking)
    {
        if (!ModelState.IsValid)
        {
            return View(booking);
        }

        booking.BookingId = bookings.Count + 1;

        bookings.Add(booking);

        TempData["SuccessMessage"] =
            "Ticket booking completed successfully.";

        return RedirectToAction("Index");
    }

    public IActionResult MovieDetails(int id)
    {
        var booking = bookings.FirstOrDefault(b => b.BookingId == id);

        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);
    }

    public IActionResult About()
    {
        return View();
    }
}