using ITicket.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        public readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var header = _dbContext.Header.ToList();

            return View(header);
        }
    }
}
