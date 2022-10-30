using Newtonsoft.Json;
using System.Text;
using Thor.Models;
using Thor.Service.Interfaces;

namespace Thor.Service
{
    public class TicketService : ITicket
    {
        private readonly string urlApi = "https://yggbrasil-odin.azurewebsites.net/api/Tarefa";

        public List<TicketModel> GetAll()
        {
            var users = new List<TicketModel>();

            try
            {
                using (var cliente = new HttpClient())
                {
                    var result = cliente.GetStringAsync(urlApi);
                    result.Wait();
                    users = JsonConvert.DeserializeObject<TicketModel[]>(result.Result).ToList();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return users;
        }
    }
}
