using ITicket.DAL.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITicket.DAL.DataContext
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {
            
        }

        public DbSet<Header> Header { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<AllEvent> AllEvents { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<KhayalKahvesi> KhayalKahvesis { get; set; }
        public DbSet<Kid> Kids { get; set; }
        public DbSet<MasterClass> MasterClasses { get; set; }
        public DbSet<Museum> Museums { get; set; }
        public DbSet<Novelty> Novelties { get; set; }
        public DbSet<Other> Others { get; set; }
        public DbSet<Pageant> Pageants { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PopularEvent> PopularEvents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<SliderImg> SliderImgs { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Tourism> Tourisms { get; set; }
        public DbSet<Weekend> Weekends { get; set; }
        public DbSet<BasketSecond> BasketSeconds { get; set;}
        public DbSet<Like> Likes { get; set; }
        public DbSet<LoadMore> LoadMores { get; set; }
        public DbSet<SellectBtn> SellectBtns { get; set;}
        public DbSet<RightNav> RightNavs { get; set; }

    }
}
