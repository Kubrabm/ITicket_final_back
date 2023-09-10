using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class SeminarController : Controller
    {
        private readonly AppDbContext _dbContext;

        public SeminarController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var seminar = _dbContext.Seminars.Take(12).ToList();
            SeminarViewModel viewModel = new SeminarViewModel
            {
                Seminars = seminar
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var seminar = _dbContext.Seminars.Find(id);

            if (seminar == null) return NotFound();

            return View(seminar);

        }
    }
}


