using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppDbContext _dbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var sliderimgs = _dbContext.SliderImgs.Take(1).ToList();
            var popularevents = _dbContext.PopularEvents.Take(6).ToList();
            var tourisms = _dbContext.Tourisms.Take(6).ToList();
            var pageants = _dbContext.Pageants.Take(6).ToList();
            var kids = _dbContext.Kids.Take(6).ToList();
            var wekkends = _dbContext.Weekends.Take(6).ToList();
            var noveltys = _dbContext.Novelties.Take(6).ToList();

            var model = new HomeViewModel
            {
               SliderImgs=sliderimgs.ToList(),
               PopularEvents= popularevents.ToList(),
               Tourisms= tourisms.ToList(),
               Pageants=pageants.ToList(),
               Kids=kids.ToList(),
               Weekends=wekkends.ToList(),
               Novelties=noveltys.ToList(),
            };

            return View(model);
        }


    }
}
