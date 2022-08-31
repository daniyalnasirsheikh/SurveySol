using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SV.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SV.WebApp.Controllers
{
    [Authorize]
    public class PollsterController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public PollsterController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = new UserViewModel { Id = user.Id, Username = user.UserName, Email = user.Email };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            string changeEmailToken = await userManager.GenerateChangeEmailTokenAsync(user, model.Email);
            var changeEmailResult = await userManager.ChangeEmailAsync(user, model.Email, changeEmailToken);

            if (!changeEmailResult.Succeeded)
            {
                model.ErrorMessage = changeEmailResult.Errors.FirstOrDefault().Description;
                return View(nameof(Update), model);
            }

            model.SuccessMessage = "Email updated successfully.";

            return View(nameof(Update), model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, model.Password);

            if (!result.Succeeded)
            {
                model.ErrorMessage = result.Errors.FirstOrDefault().Description;
                return View(nameof(Update), model);
            }

            model.SuccessMessage = "Password updated successfully.";
            model.Password = string.Empty;
            model.ConfirmPassword = string.Empty;

            return View(nameof(Update), model);
        }
    }
}
