using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class TourismController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TourismController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var tourisms = _dbContext.Tourisms.Take(12).ToList();
            TourismViewModel viewModel = new TourismViewModel
            {
                Tourisms = tourisms
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var tourisms = _dbContext.Tourisms.Find(id);

            if (tourisms == null) return NotFound();

            return View(tourisms);

        }
    }
}
