using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace RigetZooSolution.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket Booking Form
        public ActionResult BookTickets()
        {
            return View();
        }

        // POST: Handle Ticket Booking and Calculate Total Price
        [HttpPost]
        public ActionResult BookTickets(string visitorName, int adultTickets, int childTickets, int under5Tickets,
                                         int seniorTickets, int studentTickets, int disabledAdultTickets, int disabledChildTickets)
        {
            // Prices for each ticket type
            const decimal adultPrice = 25m;
            const decimal childPrice = 17m;
            const decimal under5Price = 0m;
            const decimal seniorPrice = 20m;
            const decimal studentPrice = 22.5m;
            const decimal disabledAdultPrice = 22.5m;
            const decimal disabledChildPrice = 15m;

            // Calculate total price
            decimal totalPrice = (adultTickets * adultPrice) +
                                 (childTickets * childPrice) +
                                 (under5Tickets * under5Price) +
                                 (seniorTickets * seniorPrice) +
                                 (studentTickets * studentPrice) +
                                 (disabledAdultTickets * disabledAdultPrice) +
                                 (disabledChildTickets * disabledChildPrice);

            // Pass data to the Payment view
            ViewBag.VisitorName = visitorName;
            ViewBag.AdultTickets = adultTickets;
            ViewBag.ChildTickets = childTickets;
            ViewBag.Under5Tickets = under5Tickets;
            ViewBag.SeniorTickets = seniorTickets;
            ViewBag.StudentTickets = studentTickets;
            ViewBag.DisabledAdultTickets = disabledAdultTickets;
            ViewBag.DisabledChildTickets = disabledChildTickets;
            ViewBag.TotalPrice = totalPrice;

            return View("Payment");
        }
    }
}
