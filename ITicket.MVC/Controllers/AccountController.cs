using ITicket.DAL.Data;
using ITicket.DAL.Entites;
using ITicket.MVC.Services;
using ITicket.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMailService _mailManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMailService mailManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailManager = mailManager;
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

            var user = new AppUser
            {
                UserName = model.Username,
                Fullname = model.Fullname,
                Email = model.Email,
            };

            var existUser = await _userManager.FindByNameAsync(model.Username);

            if (existUser != null)
            {
                ModelState.AddModelError("", "This username is already exist");

                return View();
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account",
                    new { userId = user.Id, token }, Request.Scheme, Request.Host.ToString());

                var mailRequest = new RequestEmail
                {
                    ToEmail = model.Email,
                    Body = $"Please confirm your account by clicking this link: " +
                        $"<a href='{confirmationLink}'>Confirm Email</a>",
                    Subject = "Confirm your email"
                };

                await _mailManager.SendEmailAsync(mailRequest);

                return RedirectToAction(nameof(Login));
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            else
            {
                return View("Error");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existUser = await _userManager.FindByNameAsync(model.Username);

            if (existUser == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect");

                return View();
            }

            var result = await _signInManager.PasswordSignInAsync
                (existUser, model.Password, isPersistent: true, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "You banned. Please try a few moments later");
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is incorrect");

                return View();
            }

            if (model.Username == "Admin")
            {
                return RedirectToAction("Index", "Dashboard", new { area = "adminpanel" });
            }
            else
            {
                var createdUser = await _userManager.FindByNameAsync(model.Username);
                var userId = createdUser.Id;

                return RedirectToAction("UserProfile", "Account", new { userId });
            }
        }

        [Authorize]
        public async Task<IActionResult> UserProfile(string userId)
        {
            var existUser = await _userManager.FindByIdAsync(userId);

            if (existUser == null)
            {
                return NotFound();
            }

            var userProfileViewModel = new UserProfileViewModel
            {
                Username = existUser.UserName,
                Fullname = existUser.Fullname,
            };

            return View(userProfileViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var username = User?.Identity?.Name;

            if (username == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(username);

            var userId = user.Id;

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }

            return RedirectToAction("UserProfile", "Account", new { userId });
        }

        public IActionResult ForgottenPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgottenPassword(ForgottenPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Enter the email address");

                return View();
            }

            var existUser = await _userManager.FindByEmailAsync(model.Email);

            if (existUser == null)
            {
                ModelState.AddModelError("", "This email address is not exist");

                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(existUser);

            var resetLink = Url.Action(nameof(ResetPassword),
                "Account", new { email = model.Email, token }, Request.Scheme, Request.Host.ToString());

            var mailRequest = new RequestEmail
            {
                ToEmail = model.Email,
                Body = resetLink,
                Subject = "Reset password link"
            };

            await _mailManager.SendEmailAsync(mailRequest);

            return RedirectToAction(nameof(Login));
        }

        public IActionResult ResetPassword(string email, string token)
        {
            return View(new ResetPasswordViewModel { Email = email, Token = token });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Anything is wrong");

                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return BadRequest();

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View();
        }
    }


}
