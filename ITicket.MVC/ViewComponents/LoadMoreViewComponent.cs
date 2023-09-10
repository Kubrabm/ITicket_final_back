using ITicket.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.ViewComponents
{
    public class LoadMoreViewComponent : ViewComponent
    {
        public readonly AppDbContext _dbContext;

        public LoadMoreViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var loadmore = _dbContext.LoadMores.ToList();

            return View(loadmore);
        }
    }
}
