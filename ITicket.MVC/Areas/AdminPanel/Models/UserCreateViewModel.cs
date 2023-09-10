using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ITicket.MVC.Areas.AdminPanel.Models
{
    public class UserCreateViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Role { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
