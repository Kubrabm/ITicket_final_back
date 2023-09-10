using ITicket.DAL.DataContext;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class BasketItemController : Controller
    {
        public readonly AppDbContext _dbContext;

        public BasketItemController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var basketitems = _dbContext.BasketItems.Take(12).ToList();

            var model = new BasketItemViewModel
            {
                BasketItems = basketitems.ToList()
            };

            return View(model);
        }
    }
}
