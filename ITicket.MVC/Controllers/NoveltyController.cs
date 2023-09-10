using ITicket.DAL.DataContext;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class NoveltyController : Controller
    {
        public readonly AppDbContext _dbContext;

        public NoveltyController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var noveltys = _dbContext.Novelties.Take(12).ToList();

            var model = new NoveltyViewModel
            {
                Novelties = noveltys.ToList()
            };

            return View(model);
        }
    }
}
