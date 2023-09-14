using System.ComponentModel.DataAnnotations;

namespace ITicket.MVC.ViewModels
{
    public class UserProfileViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Fullname { get; set; }
    }
}
