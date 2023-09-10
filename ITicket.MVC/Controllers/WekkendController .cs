using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.ViewModels
{
    public class WekkendController:Controller
    {
        public readonly AppDbContext _dbContext;

        public WekkendController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var wekkends = _dbContext.Weekends.Take(12).ToList();

            var model = new WekkendViewModel
            {
                Weekends = wekkends.ToList()
            };

            return View(model);
        }

    }
}
