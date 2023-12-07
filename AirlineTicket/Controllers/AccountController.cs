using BE;
using BLL;
using DAL;
using System;
using System.Linq;
using AirlineTicket.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AirlineTicket.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> signInManager;
        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(RegisterModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربری با این نام کاربری پیدا نشد");
                return View(model);
            }
            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "نام کاربری یا پسورد اشتباه است");
                return View(model);
            }
            return RedirectToAction("Index", "Profile");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError("", "این نام کاربری قبلا استفاده شده است");
                return View(model);
            }
            if (model.Password!= model.PasswordTwo)
            {
                ModelState.AddModelError("", "رمز عبور یکسان نیست");
                return View(model);
            }
            var newuser=new UserApp
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var addResult =await userManager.CreateAsync(newuser, model.Password);
            return RedirectToAction("Login","Account");
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
