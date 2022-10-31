using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Thor.Services;
using Thor.Data.Enums;
using Thor.ViewModel;

namespace Thor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITicketService _ticketService;

        public HomeController(ILogger<HomeController> logger, ITicketService ticketService)
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
                CountTicketsCompleted = result.Where(i => i.Status == StatusTicket.Concluido).Count(),
                CountTicketsInProgess = result.Where(i => i.Status == StatusTicket.EmAndamento).Count(),
                CountTicketsOpen = result.Where(i => i.Status == StatusTicket.Ativo).Count(),
                CountTicketsCanceled = result.Where(i => i.Status == StatusTicket.Cancelado).Count(),
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
    }
}