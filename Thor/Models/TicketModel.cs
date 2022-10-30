namespace Thor.Models
{
    public class TicketModel
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Enums.StatusTicket Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
