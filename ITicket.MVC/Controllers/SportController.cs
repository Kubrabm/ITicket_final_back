using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class SportController : Controller
    {
        private readonly AppDbContext _dbContext;

        public SportController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var sports = _dbContext.Sports.Take(12).ToList();
            SportViewModel viewModel = new SportViewModel
            {
                Sports = sports
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var sport = _dbContext.Sports.Find(id);

            if (sport == null) return NotFound();

            return View(sport);

        }
    }
}


