using Newtonsoft.Json;
using System.Text;
using Thor.Models;
using Thor.Service.Interfaces;

namespace Thor.Service
{
    public class TicketService : ITicket
    {
        private readonly string urlApi = "https://yggbrasil-odin.azurewebsites.net/api/Tickets";

        public List<TicketModel> GetAll()
        {
            var tickets = new List<TicketModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetStringAsync(urlApi);
                    result.Wait();
                    tickets = JsonConvert.DeserializeObject<TicketModel[]>(result.Result).ToList();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return tickets;
        }
    }
}
