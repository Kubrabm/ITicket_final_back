using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class KhayalKahvesiController : Controller
    {
        private readonly AppDbContext _dbContext;

        public KhayalKahvesiController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var khayalkahvesi = _dbContext.KhayalKahvesis.Take(12).ToList();
            KhayalKahvesiViewModel viewModel = new KhayalKahvesiViewModel
            {
                KhayalKahvesis=khayalkahvesi
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var khayalkahvesi = _dbContext.KhayalKahvesis.Find(id);

            if (khayalkahvesi == null) return NotFound();

            return View(khayalkahvesi);

        }
    }
}
