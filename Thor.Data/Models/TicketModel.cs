using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Thor.Data.Models
{
    [Bind]
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
