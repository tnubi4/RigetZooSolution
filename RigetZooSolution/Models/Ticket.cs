namespace RigetZooSolution.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string VisitorName { get; set; }
        public int AdultTickets { get; set; }
        public int ChildTickets { get; set; }
        public int Under5Tickets { get; set; }
        public int SeniorTickets { get; set; }
        public int StudentTickets { get; set; }
        public int DisabledAdultTickets { get; set; }
        public int DisabledChildTickets { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
