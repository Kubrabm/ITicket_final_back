using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class EticketController : Controller
    {
        public readonly AppDbContext _dbContext;

        public EticketController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {


            var model = new AllEventsViewModel
            {

            };

            return View(model);
        }
    }
}

