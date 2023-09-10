using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class AllEventsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public AllEventsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var concerts = _dbContext.Concerts.Take(6).ToList();
            var khayalkahvesi = _dbContext.KhayalKahvesis.Take(6).ToList();
            var kids = _dbContext.Kids.Take(6).ToList();
            var masterclasses = _dbContext.MasterClasses.Take(6).ToList();
            var museums = _dbContext.Museums.Take(6).ToList();
            var others = _dbContext.Others.Take(6).ToList();
            var pageants = _dbContext.Pageants.Take(6).ToList();
            var seminars = _dbContext.Seminars.Take(6).ToList();
            var sports = _dbContext.Sports.Take(6).ToList();
            var theatres = _dbContext.Theatres.Take(6).ToList();
            var tourisms = _dbContext.Tourisms.Take(6).ToList();

            var model = new AllEventsViewModel
            {
                Concerts = concerts.ToList(),
                KhayalKahvesis = khayalkahvesi.ToList(),
                Kids = kids.ToList(),
                MasterClasses = masterclasses.ToList(),
                Museums = museums.ToList(),
                Others = others.ToList(),
                Pageants = pageants.ToList(),
                Seminars = seminars.ToList(),
                Sports = sports.ToList(),
                Theatres = theatres.ToList(),
                Tourisms = tourisms.ToList()
            };

            return View(model);
        }

    }
}

