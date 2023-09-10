using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class KidController : Controller
    {
        private readonly AppDbContext _dbContext;

        public KidController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var kid = _dbContext.Kids.Take(12).ToList();
            KidViewModel viewModel = new KidViewModel
            {
                Kids = kid
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var kid = _dbContext.Kids.Find(id);

            if (kid == null) return NotFound();

            return View(kid);

        }
    }
}
