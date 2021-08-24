using AdminPanel.ViewModels;
using Buisness.Abstract;
using DataAccess.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize(Roles = RoleConstants.AdminRole + "," + RoleConstants.ModeratorRole)]
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.PageCount = Decimal.Ceiling((decimal)_userManager.Users.Count() / 5);
            ViewBag.Page = page;

            if (ViewBag.PageCount < page || page <= 0)
                return NotFound();

            var users = (User.Identity.IsAuthenticated
                ? await _userManager.Users.Where(x => x.UserName != User.Identity.Name).ToListAsync() : null);

            var usersVM = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userVM = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    City = user.City,
                    SerialNumber = user.SerialNumber,
                    FinCode = user.FinCode,
                    BirthDay = user.BirthDay,
                    Gender = user.Gender,
                    Address = user.Address,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
                    IsActive = user.IsActive
                };
                usersVM.Add(userVM);
            }

            return View(usersVM);
        }

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var existUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (existUser == null)
            {
                ModelState.AddModelError("", "Email or password is invalid.");
                return View();
            }

            if (existUser.IsActive == false)
            {
                ModelState.AddModelError("", "Your account is disabled.");
                return View();
            }

            var roles = await _userManager.GetRolesAsync(existUser);
            foreach (var role in roles)
            {
                if(role != RoleConstants.AdminRole && role != RoleConstants.ModeratorRole)
                {
                    ModelState.AddModelError("", "Email or password is invalid.");
                    return View();
                }
            }

            var loginResult = await _signInManager.PasswordSignInAsync(existUser, loginViewModel.Password, false, true);
            if (!loginResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is invalid.");
                return View();
            }

            return RedirectToAction("Index", "Dashboard");
        }

        #endregion

        #region Logout

        [Authorize(Roles = RoleConstants.AdminRole + "," + RoleConstants.ModeratorRole)]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return NotFound();
            }

            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "User");
        }

        #endregion

        #region ChangeRole

        [Authorize(Roles = RoleConstants.AdminRole)]
        public async Task<IActionResult> ChangeRole(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var changeRoleViewModel = new ChangeRoleViewModel
            {
                UserName = user.UserName,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
                Roles = GetRoles()
            };

            return View(changeRoleViewModel);
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string id, ChangeRoleViewModel changeRoleViewModel, string role)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var dbChangeRoleViewModel = new ChangeRoleViewModel
            {
                UserName = user.UserName,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
                Roles = GetRoles()
            };

            if (!ModelState.IsValid)
            {
                return View(dbChangeRoleViewModel);
            }

            string oldRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            string newRole = changeRoleViewModel.Role;
            if (oldRole != newRole)
            {
                var addResult = await _userManager.AddToRoleAsync(user, newRole);
                if (!addResult.Succeeded)
                {
                    ModelState.AddModelError("", "Some problem exist");
                    return View(dbChangeRoleViewModel);
                }

                var removeResult = await _userManager.RemoveFromRoleAsync(user, oldRole);
                if (!removeResult.Succeeded)
                {
                    ModelState.AddModelError("", "Some problem exist");
                    return View(dbChangeRoleViewModel);
                }
            }

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        [Authorize(Roles = RoleConstants.AdminRole + "," + RoleConstants.ModeratorRole)]
        public async Task<IActionResult> Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var userVM = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                SerialNumber = user.SerialNumber,
                FinCode = user.FinCode,
                BirthDay = user.BirthDay,
                Gender = user.Gender,
                Address = user.Address,
                Balance = user.Balance,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
                IsActive = user.IsActive
            };

            return View(userVM);
        }

        #endregion

        public List<string> GetRoles()
        {
            List<string> roles = new List<string>();

            roles.Add(RoleConstants.AdminRole);
            roles.Add(RoleConstants.ModeratorRole);
            roles.Add(RoleConstants.MemberRole);

            return roles;
        }
    }
}
