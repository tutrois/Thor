using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Thor.Models;
using Thor.Service.Interfaces;
using Thor.ViewModel.Ticket;
using Thor.Helpes;

namespace Thor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITicket _ticketService;

        public HomeController(ILogger<HomeController> logger, ITicket ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            var result = _ticketService.GetAll();
            var ticketsTable = result.Select(i => new TicketTableViewModel()
            {
               Id = i.Id,
               Number = i.Number,
               Title = i.Title,
               Status = i.Status,
               CreatedOn = i.CreatedOn,
               ColorStatus = convertStatusInColor(i.Status)
            }).ToList();

            var viewModel = new HomeViewModel()
            {
                TicketsTable = ticketsTable,
                CountTicketsCompleted = result.Where(i => i.Status == Enums.StatusTicket.Concluido).Count(),
                CountTicketsInProgess = result.Where(i => i.Status == Enums.StatusTicket.EmAndamento).Count(),
                CountTicketsOpen = result.Where(i => i.Status == Enums.StatusTicket.Ativo).Count(),
                CountTicketsCanceled = result.Where(i => i.Status == Enums.StatusTicket.Cancelado).Count(),
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string convertStatusInColor(Enums.StatusTicket status)
        {
            var dictionary = new Dictionary<Enums.StatusTicket, Func<string>>()
            {
                { Enums.StatusTicket.Ativo, () => "badge-success" },
                { Enums.StatusTicket.EmAndamento, () => "badge-warning" },
                { Enums.StatusTicket.Concluido, () => "badge-info" },
                { Enums.StatusTicket.Cancelado, () => "badge-danger" },
            };
            return dictionary[status]();
        }
    }
}