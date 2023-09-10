﻿using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using ITicket.MVC.Areas.AdminPanel.Data;
using ITicket.MVC.Areas.AdminPanel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITicket.MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    //[Authorize(Roles = "Admin")]
    public class UsersController : AdminController
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(AppDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new List<UserViewModel>();
            var users = await _userManager.Users.ToListAsync();
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _dbContext.UserRoles.ToListAsync();

            foreach (var user in users)
            {
                var userRole = userRoles.FirstOrDefault(x => x.UserId == user.Id);
                //var role = roles.FirstOrDefault(x => x.Id == userRole.RoleId).Name;

                model.Add(new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    //Role = role
                });

                return View(model);

            }


            return View();
        }

        public IActionResult Create()
        {

            var model = new UserCreateViewModel
            {
                Roles = GetRoles()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            var viewModel = new UserCreateViewModel
            {
                Roles = GetRoles()
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user= new AppUser 
            { 
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };

            var result=await _userManager.CreateAsync(user,model.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(viewModel);
            }

            var createdUser=await _userManager.FindByNameAsync(model.UserName);

            if (createdUser == null)
            {
                ModelState.AddModelError("", "User yaradilmadi");
            }

            result=await _userManager.AddToRoleAsync(createdUser, model.Role);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetRoles()
        {
            var roles = new List<string> { Constants.AdminRole, Constants.UserRole };

            var roleSelectedList = new List<SelectListItem>();

            roles.ForEach(x => roleSelectedList.Add(new SelectListItem(x, x)));

            return roleSelectedList;

        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user == null) return NotFound();

            var currentRole=(await _userManager.GetRolesAsync(user)).FirstOrDefault();

            var model = new UserUpdateViewModel
            {
                FirstName=user.FirstName, 
                LastName=user.LastName,
                UserName=user.UserName,
                Email=user.Email,
                CurretRole=currentRole,
                Role=currentRole,
                Roles=GetRoles()
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserUpdateViewModel model, string id)
        {

            var viewModel = new UserUpdateViewModel
            {
                Roles = GetRoles(),
                Role=model.Role
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var existUser = await _userManager.FindByIdAsync(id);

            if (existUser == null) return NotFound();

            existUser.UserName = model.UserName;
            existUser.LastName = model.LastName;
            existUser.FirstName = model.FirstName;
            existUser.Email = model.Email;

            if(model.CurretRole != model.Role)
            {
               var result = await _userManager.RemoveFromRoleAsync(existUser, model.CurretRole);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(viewModel);
                }

                result= await _userManager.AddToRoleAsync(existUser, model.Role);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(viewModel);
                }
            }
                
            var userResult= await _userManager.UpdateAsync(existUser);

            if (!userResult.Succeeded)
            {
                foreach (var error in userResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }


    }

}
