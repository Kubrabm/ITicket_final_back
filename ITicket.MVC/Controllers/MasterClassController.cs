using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITicket.MVC.Controllers
{
    public class MasterClassController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MasterClassController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var masterClasses = _dbContext.MasterClasses.Take(12).ToList();
            MasterClassViewModel viewModel = new MasterClassViewModel
            {
                MasterClasses = masterClasses
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();

            var masterClasses = _dbContext.MasterClasses.Find(id);

            if (masterClasses == null) return NotFound();

            return View(masterClasses);

        }
    }
}
