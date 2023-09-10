using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class PageantController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PageantController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var pageant = _dbContext.Pageants.Take(12).ToList();
            PageantViewModel viewModel = new PageantViewModel
            {
                Pageants = pageant
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var pageant = _dbContext.Pageants.Find(id);

            if (pageant == null) return NotFound();

            return View(pageant);

        }
    }
}
