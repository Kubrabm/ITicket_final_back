using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class OtherController : Controller
    {
        private readonly AppDbContext _dbContext;

        public OtherController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var other = _dbContext.Others.Take(12).ToList();
            OtherViewModel viewModel = new OtherViewModel
            {
                Others=other
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var other = _dbContext.Others.Find(id);

            if (other == null) return NotFound();

            return View(other);

        }
    }
}


