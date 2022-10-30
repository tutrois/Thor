using Thor.Models;

namespace Thor.Service.Interfaces
{
    public interface ITicket
    {
        List<TicketModel> GetAll();
    }
}
