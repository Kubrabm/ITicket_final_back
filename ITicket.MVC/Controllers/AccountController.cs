using ITicket.DAL.Entites;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ITicket.MVC.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var User =new AppUser 
            {
                FirstName=model.FullName,
                UserName=model.UserName,
                Email=model.Email,
                PhoneNumber=model.PhoneNumber
            };


            var existUsername = await _userManager.FindByNameAsync(model.UserName);

            if (existUsername != null)
            {
                ModelState.AddModelError("Username", "Bu adda user mövcuddur");
                return View();
            }

            var result = await _userManager.CreateAsync(User, model.Password);

            if (result.Succeeded)
            {
                _signInManager.SignInAsync(User, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login (LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var existUser= await _userManager.FindByNameAsync(model.UserName);

                if (existUser == null)
                {
                    ModelState.AddModelError("", "Usernae isnot correct");
                    return View();
                }

                var result = await _signInManager.PasswordSignInAsync(existUser, model.Password, false,true);

                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Email tesdiqlenmelidir");
                    return View();
                }

                if (result.IsLockedOut) 
                {
                    ModelState.AddModelError("", "This user locked out");
                    return View();
                }

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Invalid credentials");
                    return View();
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }


        public IActionResult ChangePassword()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction(nameof(Index), "Home");
            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var existUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (existUser == null)
            {
                return BadRequest();
            }

            var result = await _userManager.ChangePasswordAsync(existUser, model.CurrentPaswword, model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
