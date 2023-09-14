using Microsoft.AspNetCore.Identity;

namespace ITicket.DAL.Entites
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
