using ITicket.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.ViewComponents
{
    public class BasketSecondViewComponent : ViewComponent
    {
        public readonly AppDbContext _dbContext;

        public BasketSecondViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var basketsecond = _dbContext.BasketSeconds.ToList();

            return View(basketsecond);
        }
    }

}
