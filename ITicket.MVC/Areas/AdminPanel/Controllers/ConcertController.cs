using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITicket.MVC.Areas.AdminPanel.Controllers
{
    public class ConcertController:AdminController
    {
        private readonly AppDbContext _dbContext;

        public ConcertController( AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var concerts=await _dbContext.Concerts.ToListAsync();


            return View(concerts);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();

            var concert = await _dbContext.Concerts.FirstOrDefaultAsync(x => x.Id == id);

            if (concert == null) return NotFound();

            return View(concert);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Concert concert)
        {
            //return Content(concert.Name + " " + concert.ImgUrl + " " + concert.BgImgUrl + " " + concert.DetailPageImg + " " + concert.Date + " " + concert.Location + " " + concert.Price + "  " + concert.EeventId);

            if(!ModelState.IsValid)
            {
                return View();
            }
            var isExist= await _dbContext.Concerts.AnyAsync(x=>x.Name.ToLower().Equals(concert.Name.ToLower()));
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda konsert mövcuddur");
                return View();
            }

            await _dbContext.Concerts.AddAsync(concert);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var concert =await _dbContext.Concerts.FindAsync(id);

            if(concert==null) return NotFound();

             _dbContext.Concerts.Remove(concert);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update (int?id)
        {
            if(id == null) return NotFound();

            var concert= await _dbContext.Concerts.FindAsync(id);

            if(concert==null) return NotFound();

            return View(concert);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Concert concert)
        {
            if(id == null) return NotFound();

            if(id!=concert.Id) return BadRequest();

            var existConcert = await _dbContext.Concerts.FindAsync(id);

            //var existName = await _dbContext.Concerts.AnyAsync(x => x.Name.ToLower().Equals(concert.Name.ToLower()) && x.Id!=id);

            //if (existName)
            //{
            //    ModelState.AddModelError("Name", "Bu adda konsert mövcuddur");
            //    return View();
            //}

            existConcert.Name=concert.Name;

            existConcert.ImgUrl = concert.ImgUrl;

            existConcert.BgImgUrl = concert.BgImgUrl;

            existConcert.DetailPageImg = concert.DetailPageImg;

            existConcert.Price = concert.Price;

            existConcert.Location = concert.Location;

            existConcert.Date = concert.Date;

            existConcert.EeventId = concert.EeventId;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof (Index));

        }

    }
}
