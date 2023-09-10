using Microsoft.AspNetCore.Identity;

namespace ITicket.DAL.Entites
{
    public class AppUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
