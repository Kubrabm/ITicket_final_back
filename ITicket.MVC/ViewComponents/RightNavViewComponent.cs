using ITicket.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.ViewComponents
{
    public class RightNavViewComponent : ViewComponent
    {
        public readonly AppDbContext _dbContext;

        public RightNavViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var rightnav = _dbContext.RightNavs.ToList();

            return View(rightnav);
        }
    }
    
  
}
