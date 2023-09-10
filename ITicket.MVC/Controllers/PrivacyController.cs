using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class PrivacyController : Controller
    {
        public readonly AppDbContext _dbContext;

        public PrivacyController(AppDbContext appDbContext)
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

