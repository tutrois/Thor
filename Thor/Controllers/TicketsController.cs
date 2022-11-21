using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thor.Data.Enums;
using Thor.Data.Models;
using Thor.Services;
using Thor.ViewModel;

namespace Thor.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;

        }

        // GET: TicketsController
        public ActionResult Index()
        {
            var result = _ticketService.GetAll();

            var ticketsTable = result.Select(i => new TicketTableViewModel()
            {
                Id = i.Id,
                Number = i.Number,
                Title = i.Title,
                Status = i.Status,
                CreatedOn = i.CreatedOn,
                Description = i.Description.Length <= 50 ? i.Description : i.Description.Substring(0, 50) +"...",
                ColorStatus = convertStatusInColor(i.Status)
            }).ToList();

            return View(ticketsTable);
        }

        // GET: TicketsController/Details/5
        public ActionResult Details(Guid id)
        {
            var result = _ticketService.GetById(id);

            return View(result);
        }

        
        private string convertStatusInColor(StatusTicket status)
        {
            var dictionary = new Dictionary<StatusTicket, Func<string>>()
            {
                { StatusTicket.Ativo, () => "badge-success" },
                { StatusTicket.EmAndamento, () => "badge-warning" },
                { StatusTicket.Concluido, () => "badge-info" },
                { StatusTicket.Cancelado, () => "badge-danger" },
            };
            return dictionary[status]();
        }

        // GET: TicketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var result = _ticketService.GetById(id);

            return View(result);
        }

        // POST: TicketsController/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid Id, StatusTicket Status)
        {
            var ticket = new TicketModel()
            {
                Id = Id,
                Status = Status
            };
            var result = _ticketService.UpdateTicketStatus(ticket);

            return RedirectToAction(nameof(Index));
    }

        // GET: TicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
