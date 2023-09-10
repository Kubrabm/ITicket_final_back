using ITicket.DAL.DataContext;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class PopularEventsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public PopularEventsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var popularevents = _dbContext.PopularEvents.Take(12).ToList();

            var model = new PopularEventsViewModel
            {
                PopularEvents = popularevents.ToList()
            };

            return View(model);
        }
    }
}


