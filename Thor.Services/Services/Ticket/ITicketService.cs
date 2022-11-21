using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thor.Data.Models;

namespace Thor.Services
{
    public interface ITicketService
    {
        List<TicketModel> GetAll();
        TicketModel GetById(Guid ticketId);
        bool UpdateTicketStatus(TicketModel ticket);
    }
}
