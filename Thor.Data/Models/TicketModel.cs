using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thor.Data.Models
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
