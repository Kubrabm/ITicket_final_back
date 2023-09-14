using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITicket.MVC.Areas.AdminPanel.Controllers
{
    public class KidController:AdminController
    {
        private readonly AppDbContext _dbContext;

        public KidController( AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var kids=await _dbContext.Kids.ToListAsync();


            return View(kids);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();

            var kid = await _dbContext.Kids.FirstOrDefaultAsync(x => x.Id == id);

            if (kid == null) return NotFound();

            return View(kid);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kid kid)
        {
            //return Content(concert.Name + " " + concert.ImgUrl + " " + concert.BgImgUrl + " " + concert.DetailPageImg + " " + concert.Date + " " + concert.Location + " " + concert.Price + "  " + concert.EeventId);

            if(!ModelState.IsValid)
            {
                return View();
            }
            var isExist= await _dbContext.Kids.AnyAsync(x=>x.Name.ToLower().Equals(kid.Name.ToLower()));
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda konsert mövcuddur");
                return View();
            }

            await _dbContext.Kids.AddAsync(kid);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var kid =await _dbContext.Kids.FindAsync(id);

            if(kid ==null) return NotFound();

             _dbContext.Kids.Remove(kid);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update (int?id)
        {
            if(id == null) return NotFound();

            var kid= await _dbContext.Kids.FindAsync(id);

            if(kid==null) return NotFound();

            return View(kid);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Kid kid)
        {
            if(id == null) return NotFound();

            if(id!=kid.Id) return BadRequest();

            var existKid = await _dbContext.Kids.FindAsync(id);

            //var existName = await _dbContext.Concerts.AnyAsync(x => x.Name.ToLower().Equals(concert.Name.ToLower()) && x.Id!=id);

            //if (existName)
            //{
            //    ModelState.AddModelError("Name", "Bu adda konsert mövcuddur");
            //    return View();
            //}

            existKid.Name=kid.Name;

            existKid.ImgUrl = kid.ImgUrl;

            existKid.BgImgUrl = kid.BgImgUrl;

            existKid.DetailPageImg = kid.DetailPageImg;

            existKid.Price = kid.Price;

            existKid.Location = kid.Location;

            existKid.Date = kid.Date;

            existKid.EeventId = kid.EeventId;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof (Index));

        }

    }
}
