using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Thor.Data.Models;


namespace Thor.Services 
{ 
    public class TicketService : ITicketService
    {
        private readonly string urlApi = "https://yggbrasil-odin.azurewebsites.net/api/Tickets/";

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

        public TicketModel GetById(Guid ticketId)
        {
            var ticket = new TicketModel();
            try
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetStringAsync($"{urlApi}{ticketId}");
                    result.Wait();
                    ticket = JsonConvert.DeserializeObject<TicketModel>(result.Result);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return ticket;
        }

        public bool UpdateTicketStatus(TicketModel ticket)
        {
            try
            {
                using (var client = new HttpClient())
                {


                    string jsonObject = JsonConvert.SerializeObject(ticket);

                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                    var path = Path.Combine($"{urlApi}",$"{ticket.Id}");
                    var result = client.PostAsJsonAsync(path, content);
                    result.Wait();
                    var retorno = result.Result.Content.ReadAsStringAsync();
                    var pro = JsonConvert.DeserializeObject<TicketModel>(retorno.Result);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return true;
        }
    }
}
