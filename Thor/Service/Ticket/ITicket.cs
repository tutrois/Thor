using Thor.Models;

namespace Thor.Service
{
    public interface ITicket
    {
        List<TicketModel> GetAll();
    }
}
