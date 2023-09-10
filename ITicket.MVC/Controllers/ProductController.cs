using ITicket.DAL.DataContext;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var product = _dbContext.Products.Take(12).ToList();
            ProductViewModel viewModel = new ProductViewModel
            {
                Products = product,
            };
            return View(viewModel);
        }

    }
}


