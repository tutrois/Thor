using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Thor.Enums;

namespace Thor.Models
{
    public class TicketModel
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.StatusTicket Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
