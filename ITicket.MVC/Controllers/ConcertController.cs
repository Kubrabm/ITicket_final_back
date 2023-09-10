using ITicket.DAL.DataContext;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class ConcertController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ConcertController(AppDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public IActionResult Index()
        {
            var concert=_dbContext.Concerts.Take(12).ToList();
            ConcertViewModel viewModel = new ConcertViewModel
            {
                Concerts = concert
            };
            return View(viewModel);
        }

        public IActionResult Details(int?id)
        {
            if (id == null) return BadRequest();

            var concert = _dbContext.Concerts.Find(id);

            if (concert == null) return NotFound();

            return View(concert);

        }
    }
}
