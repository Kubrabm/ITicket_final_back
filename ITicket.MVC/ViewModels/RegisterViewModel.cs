using System.ComponentModel.DataAnnotations;

namespace ITicket.MVC.ViewModels
{
    public class RegisterViewModel
    {
        public string? FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]

        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
