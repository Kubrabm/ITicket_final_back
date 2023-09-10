using ITicket.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.ViewComponents
{
    public class FooterViewComponent: ViewComponent
    {
        public readonly AppDbContext _dbContext;
        public FooterViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var footer = _dbContext.Footer.ToList();

            return View(footer);
        }
    }
}
