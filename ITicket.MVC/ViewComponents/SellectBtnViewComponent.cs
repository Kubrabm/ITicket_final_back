using ITicket.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.ViewComponents
{
    public class SellectBtnViewComponent : ViewComponent
    {
        public readonly AppDbContext _dbContext;

        public SellectBtnViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var sellectbtns = _dbContext.SellectBtns.ToList();

            return View(sellectbtns);
        }
    }

}
