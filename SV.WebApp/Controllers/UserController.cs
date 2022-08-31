using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SV.Data;
using SV.WebApp.Models;
using SV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SV.Business.Interfaces;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace SV.WebApp.Controllers
{
    [Authorize(Roles = "Admin,User Manager")]
    public class UserController : Controller
    {
        private readonly IUsersLogRepository userRepository;
        private readonly iDepartmentRepository departmentRepository;
        private readonly iUserDepartmentRepository userDepartmentRepository;
        private readonly ILogger<UserController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(ILogger<UserController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUsersLogRepository userRepository, iDepartmentRepository departmentRepository, iUserDepartmentRepository userDepartmentRepository)
        {
            this.userDepartmentRepository = userDepartmentRepository;
            this.departmentRepository = departmentRepository;
            this.userRepository = userRepository;
            this.logger = logger;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            
            var users = userManager.Users.Where(x => x.UserName != User.Identity.Name).ToList();
            var models = new List<UserViewModel>();

            foreach (var user in users)
            {
                var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();
                models.Add(new UserViewModel { Id = user.Id, Username = user.UserName, Email = user.Email, Role = role });
            }

            models = models.Where(x => x.Role != "Admin").ToList();

            return View(models);
        }

        public IActionResult Create()
        {
            if (User.IsInRole("User Manager"))
            {
                ViewBag.IsUserManager = true;
            }
            else
            {
                ViewBag.IsUserManager = false;
            }
            ViewBag.Departments = departmentRepository.GetAllDepartments();
            return View(new UserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            
            if (model.Username.Length < 3)
            {
                model.ErrorMessage = "Username must be atleast 3 characters long.";
                return View(nameof(Create), model);
            }
            if (model.Username.Length > 8)
            {
                model.ErrorMessage = "Username cannot exceed 8 characters.";
                return View(nameof(Create), model);
            }

            if (string.Equals(model.Username, model.Password))
            {
                model.ErrorMessage = "Username & Password cannot be the same.";
                return View(nameof(Create), model);
            }

            if (DateTime.TryParse(model.Password, out DateTime result) )
            {
                model.ErrorMessage = "Cannot use date/birth date as password.";
                return View(nameof(Create), model);
            }

            if (!string.Equals(model.Password, model.ConfirmPassword))
            {
                model.ErrorMessage = "Password & Confirm Password not match.";
                return View(nameof(Create), model);
            }

            var userWithEmail = await userManager.FindByEmailAsync(model.Email);

            if (userWithEmail != null)
            {
                model.ErrorMessage = "User with the email address already exist!";
                return View(nameof(Create), model);
            }

            var user = new IdentityUser { UserName = model.Username, Email = model.Email };
            var userResult = await userManager.CreateAsync(user, model.Password);

            if (!userResult.Succeeded)
            {
                model.ErrorMessage = userResult.Errors.FirstOrDefault().Description;
                return View(nameof(Create), model);
            }

            System.DateTime dateCreated = DateTime.Now;
            userRepository.AddNewUser(dateCreated, user.Id, model.Username);

            StringBuilder DepartmentIds = new StringBuilder();

            if (model.Departments != null)
            {
                foreach (var item in model.Departments)
                {
                    DepartmentIds.Append(item + ",");
                }
            }

            
            string DepartIds = Convert.ToString(DepartmentIds);
            DepartIds = DepartIds.TrimEnd(',');
            userDepartmentRepository.MapUserDepartment(user.Id, DepartIds);

            var roleResult = await userManager.AddToRoleAsync(user, model.Role);

            if (!roleResult.Succeeded)
            {
                model.ErrorMessage = roleResult.Errors.FirstOrDefault().Description;
                return View(nameof(Create), model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();
            if (role.Equals("User Manager"))
            {
                ViewBag.IsUserManager = true;
                ViewBag.UserRole = role;
            }
            else
            {
                ViewBag.IsUserManager = false;
                ViewBag.UserRole = role;
            }


            //ViewBag.UserRole = role;
            ViewBag.Departments = departmentRepository.GetAllDepartments();
            var model = new UserViewModel { Id = user.Id, Username = user.UserName, Email = user.Email, Role = role };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            var roles = await userManager.GetRolesAsync(user);
            var roleRemoveResult = await userManager.RemoveFromRolesAsync(user, roles);

            if (!roleRemoveResult.Succeeded)
            {
                model.ErrorMessage = roleRemoveResult.Errors.FirstOrDefault().Description;
                return View(nameof(Edit), model);
            }

            var roleAddResult = await userManager.AddToRoleAsync(user, model.Role);

            if (!roleAddResult.Succeeded)
            {
                model.ErrorMessage = roleAddResult.Errors.FirstOrDefault().Description;
                return View(nameof(Edit), model);
            }

            StringBuilder DepartmentIds = new StringBuilder();

            if (model.Departments != null)
            {
                foreach (var item in model.Departments)
                {
                    DepartmentIds.Append(item + ",");
                }
            }


            string DepartIds = Convert.ToString(DepartmentIds);
            DepartIds = DepartIds.TrimEnd(',');
            userDepartmentRepository.UpdateUserDepartment(user.Id, DepartIds);

            string changeEmailToken = await userManager.GenerateChangeEmailTokenAsync(user, model.Email);
            var changeEmailResult = await userManager.ChangeEmailAsync(user, model.Email, changeEmailToken);

            if (!changeEmailResult.Succeeded)
            {
                model.ErrorMessage = changeEmailResult.Errors.FirstOrDefault().Description;
                return View(nameof(Edit), model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await  userManager.ResetPasswordAsync(user, token, model.Password); 

            if (!result.Succeeded)
            {
                model.ErrorMessage = result.Errors.FirstOrDefault().Description;
                return View(nameof(Edit), model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var model = new UserViewModel { Id = user.Id, Username = user.UserName, Email = user.Email };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(UserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            var result = await userManager.DeleteAsync(user);
            userRepository.DeleteInactiveUsers(user.UserName);
            userDepartmentRepository.DeleteUserDepartments(user.Id);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            model.ErrorMessage = result.Errors.FirstOrDefault().Description;

            return RedirectToAction(nameof(Index));
        }
    }
}
