using Thor.Data.Enums;

namespace Thor.ViewModel
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
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusTicket Status { get; set; }
        public string ColorStatus { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
