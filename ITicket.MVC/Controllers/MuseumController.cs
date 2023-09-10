using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class MuseumController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MuseumController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var museums = _dbContext.Museums.Take(12).ToList();
            MuseumViewModel viewModel = new MuseumViewModel
            {
                Museums = museums
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var museums = _dbContext.Museums.Find(id);

            if (museums == null) return NotFound();

            return View(museums);

        }
    }
}