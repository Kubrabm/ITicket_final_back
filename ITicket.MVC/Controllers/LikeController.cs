using ITicket.DAL.DataContext;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class LikeController : Controller
    {
        public readonly AppDbContext _dbContext;

        public LikeController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var Likes = _dbContext.Likes.Take(12).ToList();

            var model = new LikeViewModel
            {
                likes = Likes.ToList()
            };

            return View(model);
        }
    }
}
