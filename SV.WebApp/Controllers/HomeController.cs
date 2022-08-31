using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Common;
using SV.Models.Entities;
using SV.WebApp.HTTPHelpers.Interfaces;
using SV.WebApp.Models;
using SV.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace SV.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Pollster")]
    public class HomeController : Controller
    {
        private readonly IUsersLogRepository userRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly ISurveyResponseProfileRepository SurveyResponseProfileRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ISurveyRepository surveyRepository;

        public HomeController(ILogger<HomeController> logger, ISurveyResponseProfileRepository surveyResponseProfileRepository, 
            UserManager<IdentityUser> userManager, ISurveyRepository surveyRepository, IUsersLogRepository userRepository)
        {
            _logger = logger;
            this.userRepository = userRepository;
            this.SurveyResponseProfileRepository = surveyResponseProfileRepository;
            this.userManager = userManager;
            this.surveyRepository = surveyRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.DashboardActive = "current";
            ViewBag.TotalSurvey = surveyRepository.GetAllCount();
            ViewBag.PublishSurvey = surveyRepository.GetAllPublishCount();
            ViewBag.UnPublishSurvey = surveyRepository.GetAllUnPublishCount();
            ViewBag.CloseSurvey = surveyRepository.GetAllCloseCount();

            List<UserLogs> inactiveUserList = userRepository.GetAllUserLogs();
            

            foreach (var i in inactiveUserList)
            {
                try
                {
                    userRepository.DeleteInactiveUsers(i.UserName);
                    var iul = await userManager.FindByNameAsync(i.UserName);
                    await userManager.DeleteAsync(iul);
                }
                catch (Exception)
                {
                }

            }

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var surveys = await SurveyResponseProfileRepository.GetLatestFiveResponsesByUserId(user.Id);

            //foreach (var survey in surveys)
            //{
            //    survey.FullName = surveyRepository.GetByID(survey.SurveyId)?.Name;
            //}

            return View(surveys);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
