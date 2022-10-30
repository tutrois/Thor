namespace Thor.ViewModel.Ticket
{
    public class HomeViewModel
    {
        public int CountTicketsOpen { get; set; }
        public int CountTicketsInProgess { get; set; }
        public int CountTicketsCompleted { get; set; }
        public int CountTicketsCanceled { get; set; }
        public List<TicketTableViewModel>? TicketsTable { get; set; }
    }

    public class TicketTableViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.StatusTicket Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ColorStatus { get; set; }
    }
}
