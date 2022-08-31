﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SV.Business.Interfaces;
using SV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersLogRepository userRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUsersLogRepository userRepository)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() { UserName = model.Username, Email = model.Email };
                IdentityResult res = await userManager.CreateAsync(user, model.Password);

                if (res.Succeeded)
                {
                    model.SuccessMessage = "Successfully Registered!";
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    
                }
            }
            else
            {
                ModelState.AddModelError("", "Please fill all required fields");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult DefaultPage()
        {
            return View();
        }

        //[Route("/admin")]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("User Manager"))
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(new LoginViewModel());
        }

        //[Route("/admin")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() { UserName = model.Username };
                var res = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, false);

                if (res.Succeeded)
                {
                    System.DateTime lastLoginDate = DateTime.Now;
                    //string sqlFormattedDate = dateCreated.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    userRepository.InsertLastLoggedInDate(lastLoginDate, model.Username);

                    return RedirectToAction(nameof(Login));
                }
                

                model.ErrorMessage = "Invalid username or password.";
            }
            else
            {
                model.ErrorMessage = "Username and password is required";
            }

            model.Password = string.Empty;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View(new ForgetPasswordViewModel());
        }

        [HttpPost]
        public IActionResult ForgetPassword(ForgetPasswordViewModel model)
        {
            model.SuccessMessage = "Email sent Successfully.";
            model.Email = string.Empty;
            model.ErrorMessage = string.Empty;
            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
