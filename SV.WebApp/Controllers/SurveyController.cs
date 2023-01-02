using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SV.Business.Interfaces;
using SV.Models.Entities;
using SV.WebApp.Models;
using SV.WebApp.Services;
using SV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Web;

namespace SV.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Pollster")]
    public class SurveyController : Controller
    {
        private readonly iEmailRepository emailRepository;
        private readonly ISurveyRepository surveyRepository;
        private readonly iDepartmentRepository departmentRepository;
        private readonly iUserDepartmentRepository userdepartmentRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityUser> roleManager;
        private readonly IUserShareSurveyRepository userShareSurveyRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly FileService fileService;
        private readonly IRepository<Answer> repositoryAnswer;
        private readonly IRepository<SurveyResponseProfile> repositorySRP;
        private readonly IConfiguration configuration;
        private readonly ISurveyResponseProfileRepository surveyResponseProfileRepository;


        public SurveyController(iEmailRepository emailRepository,iUserDepartmentRepository userdepartmentRepository, iDepartmentRepository departmentRepository, ISurveyRepository surveyRepository, UserManager<IdentityUser> userManager, IUserShareSurveyRepository userShareSurveyRepository,
            IQuestionRepository questionRepository, FileService fileService, IRepository<Answer> repositoryAnswer, IRepository<SurveyResponseProfile> repositorySRP, ISurveyResponseProfileRepository surveyResponseProfileRepository)
        {
            this.departmentRepository = departmentRepository;
            this.surveyRepository = surveyRepository;
            this.userManager = userManager;
            this.userShareSurveyRepository = userShareSurveyRepository;
            this.questionRepository = questionRepository;
            this.fileService = fileService;
            this.repositoryAnswer = repositoryAnswer;
            this.repositorySRP = repositorySRP;
            this.configuration = configuration;
            this.surveyResponseProfileRepository = surveyResponseProfileRepository;
            this.userdepartmentRepository = userdepartmentRepository;
            this.emailRepository = emailRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ManageSurveyActive = "current";
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var models = surveyRepository.GetAll(User.IsInRole("Admin"), user.Id);
            //foreach (var item in models)
            //{
            //    item.Department = departmentRepository.GetDepartmentByDepartmentID(item.DepartmentIds);
            //}
            
            return View(models);
        }


        public IActionResult Create()
        {
            ViewBag.CreateSurveyActive = "current";
            ViewBag.Departments = departmentRepository.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Survey model, IFormFile logo, IFormFile banner, IFormFile background)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            model.UserId = user.Id;
            model.IsSubmitted = true;
            model.LogoPath = fileService.Save(logo);
            model.BannerPath = fileService.Save(banner);
            model.BackgroundImagePath = fileService.Save(background);

            StringBuilder DepartmentIds = new StringBuilder();
            foreach (var item in model.Department)
            {
                DepartmentIds.Append(item + ",");
            }

            string DepartIds = Convert.ToString(DepartmentIds);
            DepartIds = DepartIds.TrimEnd(',');
            model.DepartmentIds = DepartIds;


            surveyRepository.Insert(model);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }

            var model = surveyRepository.GetByID(id);
            ViewBag.EditDepartments = model.DepartmentIds.Split(',');
            ViewBag.Departments = departmentRepository.GetAllDepartments();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Survey model, IFormFile logo, IFormFile banner, IFormFile background)
        {
            if (logo != null)
            {
                fileService.Remove(model.LogoPath);
                model.LogoPath = fileService.Save(logo);
            }

            if (banner != null)
            {
                fileService.Remove(model.BannerPath);
                model.BannerPath = fileService.Save(banner);
            }

            if (background != null)
            {
                fileService.Remove(model.BackgroundImagePath);
                model.BackgroundImagePath = fileService.Save(background);
            }

            
            if (model.Department != null)
            {
                StringBuilder DepartmentIds = new StringBuilder();
                foreach (var item in model.Department)
                {
                    DepartmentIds.Append(item + ",");
                }

                string DepartIds = Convert.ToString(DepartmentIds);
                DepartIds = DepartIds.TrimEnd(',');
                model.DepartmentIds = DepartIds;
            }

            model.IsRejected = false;
            model.IsLaunched = false;
            model.IsSubmitted = true;
            var result = surveyRepository.Update(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }

            var model = surveyRepository.GetByID(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Survey model)
        {
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(model.Id, user.Id))
                {
                    return NotFound();
                }
            }

            fileService.Remove(model.LogoPath);
            fileService.Remove(model.BannerPath);
            fileService.Remove(model.BackgroundImagePath);

            surveyRepository.Delete(model.Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveImage(int id, string tag)
        {
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }

            var model = surveyRepository.GetByID(id);

            if (tag == "logo")
            {
                if (fileService.Remove(model.LogoPath))
                {
                    model.LogoPath = null;
                }
            }

            if (tag == "banner")
            {
                if (fileService.Remove(model.BannerPath))
                {
                    model.BannerPath = null;
                }
            }

            if (tag == "background")
            {
                if (fileService.Remove(model.BackgroundImagePath))
                {
                    model.BackgroundImagePath = null;
                }
            }

            surveyRepository.Update(model);

            return RedirectToAction(nameof(Edit), new { id = id });
        }

        public async Task<IActionResult> Share(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }
            
            var survey = surveyRepository.GetByID(id);

            List<IdentityUser> users = new List<IdentityUser>();

            if (!User.IsInRole("Admin"))
            {
                users.Add(userManager.Users.Where(x => x.UserName.Equals("Admin")).FirstOrDefault());
            }

            users.AddRange(await userManager.GetUsersInRoleAsync("Pollster"));
            users.AddRange(await userManager.GetUsersInRoleAsync("Reviewer"));

            // This code gets only those users which are mapped to the department of the survey
            //string[] surveyDepartmentIDs = survey.DepartmentIds.Split(',');
            //List<string> userDepartmentIDs = new List<string>();
            //for (int i = 0; i < surveyDepartmentIDs.Length; i++)
            //{
            //    userDepartmentIDs.AddRange(userdepartmentRepository.GetUsersByDepartmentIDs(surveyDepartmentIDs[i]));
            //}
            //var Currentuser = await userManager.FindByNameAsync(User.Identity.Name);
            //userDepartmentIDs.Remove(Currentuser.Id);
            //foreach (var item in userDepartmentIDs)
            //{
            //    users.Add(await userManager.FindByIdAsync(item)); 
            //}
            //HashSet<IdentityUser> uniqueUsers = new HashSet<IdentityUser>();
            //foreach (var item in users)
            //{
            //    uniqueUsers.Add(item);
            //}

            var userShareSurveys = await userShareSurveyRepository.GetBySurveyId(id);

            List<IdentityUser> usersExceptLoggedInUser = new List<IdentityUser>();
            foreach (var item in users)
            {   
                if (!item.UserName.Equals(User.Identity.Name))
                {
                    usersExceptLoggedInUser.Add(item);
                }
            }
            var model = new SurveyShareViewModel(survey, usersExceptLoggedInUser, userShareSurveys, User.Identity.Name);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Share(SurveyShareViewModel model)
        {
            List<UserShareSurvey> userShareSurveys = new List<UserShareSurvey>();

            foreach (var item in model.Users)
            {
                if (item.IsChecked)
                {
                    userShareSurveys.Add(new UserShareSurvey
                    {
                        SurveyId = model.SurveyId,
                        UserId = item.UserId
                    });
                }
            }

            await userShareSurveyRepository.Save(userShareSurveys);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Preview(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }

            var survey = surveyRepository.GetByID(id);

            var questions = await questionRepository.GetBySurveyId(id);
            var model = new LauchSurveyViewModel(survey, questions);
            model.Options = model.Options.OrderBy(q => q.Question.Order).ToList();

            return View("Preview", model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> PreviewQuestion(int id, string answerText)
        {
            var parentQuestion = questionRepository.GetByID(id);

            if (parentQuestion != null && parentQuestion.LogicalQuestionText == answerText)
            {
                var questions = await questionRepository.GetChildByParentQuestionId(id);
                var survey = surveyRepository.GetByID(parentQuestion.SurveyId);
                var model = new LauchSurveyViewModel(survey, questions) { };
                model.Options[0].AnswerIndex = questions.FirstOrDefault().Id;
                return PartialView("_PreviewQuestion", model.Options[0]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Preview(List<AnswerViewModel> models, int surveyId)
        {
            int srpId = repositorySRP.Insert(new SurveyResponseProfile { Id = 0, SurveyId = surveyId, FullName = "", ResponseOn = DateTime.Now });

            foreach (var model in models)
            {
                var answer = model;
                answer.SurveyResponseProfileId = srpId;
                answer.AnswerText = String.IsNullOrWhiteSpace(answer.AnswerText) ? "" : answer.AnswerText;

                if (model.Doc != null)
                {
                    answer.DocPath = fileService.Save(model.Doc);
                }

                repositoryAnswer.Insert(answer);
            }

            return View("SurveyCompleted");
        }

        [AllowAnonymous]
        public async Task<IActionResult> SurveyResponse(int id)
        {
            var survey = surveyRepository.GetByID(id);

            if (survey.IsLaunched)
            {
                int totalSurveyResponses = surveyResponseProfileRepository.TotalResponses(id);
                int maxResponses = Convert.ToInt32(survey.MaxResponse);

                if (maxResponses != 0)
                {
                    if (totalSurveyResponses >= maxResponses)
                    {
                        ViewBag.Message = "Survey is either closed or expired";
                        ViewBag.Title = "Survey closed / expired";
                        return View("SurveyExpired");
                    }
                }

                if (survey.StartDate != null && System.DateTime.Now < survey.StartDate)
                {
                    ViewBag.Message = "Survey not started";
                    ViewBag.Title = "Survey not started";
                    return View("SurveyExpired");
                }
                else if (survey.EndDate != null && DateTime.Now > survey.EndDate)
                {
                    ViewBag.Message = "Survey expired";
                    ViewBag.Title = "Survey expired";
                    return View("SurveyExpired");
                }

            }
            else
            {
                ViewBag.Message = "Survey not available";
                ViewBag.Title = "Survey not available";
                return View("SurveyExpired");
            }

            var questions = await questionRepository.GetBySurveyId(id);
            var model = new LauchSurveyViewModel(survey, questions);
            model.Options = model.Options.OrderBy(q => q.Question.Order).ToList();

            return View("Preview", model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SurveyResponse(List<AnswerViewModel> models, int surveyId)
        {
            int srpId = repositorySRP.Insert(new SurveyResponseProfile { Id = 0, SurveyId = surveyId, FullName = "", ResponseOn = DateTime.Now });

            foreach (var model in models)
            {
                var answer = model;
                answer.SurveyResponseProfileId = srpId;
                answer.AnswerText = String.IsNullOrWhiteSpace(answer.AnswerText) ? "" : answer.AnswerText;

                if (model.Doc != null)
                {
                    answer.DocPath = fileService.Save(model.Doc);
                }

                repositoryAnswer.Insert(answer);
            }

            return View("SurveyCompleted");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/survey/surveyresponse/{Id}/{email}")]
        public async Task<IActionResult> SurveyResponse(SurveyResponseViewModel smodel)
        {
            List<SurveySharedWithCustomers> flagUser = emailRepository.GetFlaggedUserData(smodel.Id);
            var survey = surveyRepository.GetByID(smodel.Id);



            if (survey.IsLaunched)
            {
                int totalSurveyResponses = surveyResponseProfileRepository.TotalResponses(smodel.Id);
                int maxResponses = Convert.ToInt32(survey.MaxResponse);

                if (maxResponses != 0)
                {
                    if (totalSurveyResponses >= maxResponses)
                    {
                        ViewBag.Message = "Survey is either closed or expired";
                        ViewBag.Title = "Survey closed / expired";
                        return View("SurveyExpired");
                    }
                }

                if (survey.StartDate != null && DateTime.Now < survey.StartDate)
                {
                    ViewBag.Message = "Survey not started";
                    ViewBag.Title = "Survey not started";
                    return View("SurveyExpired");
                }
                else if (survey.EndDate != null && DateTime.Now > survey.EndDate)
                {
                    ViewBag.Message = "Survey expired";
                    ViewBag.Title = "Survey expired";
                    return View("SurveyExpired");
                }

            }
            else
            {
                ViewBag.Message = "Survey not available";
                ViewBag.Title = "Survey not available";
                return View("SurveyExpired");
            }

            var questions = await questionRepository.GetBySurveyId(smodel.Id);
            var model = new LauchSurveyViewModel(survey, questions);
            model.Options = model.Options.OrderBy(q => q.Question.Order).ToList();

            foreach (var item in flagUser)
            {
                if (item.Email.Equals(smodel.email))
                {
                    if (item.HasSubmitted == false)
                    {
                        return View("Preview", model);
                    }
                    else
                    {
                        ViewBag.Message = "You can submit the survey only once";
                        ViewBag.Title = "Survey already Submitted";
                        return View("SurveyExpired");
                    }

                }

            }
            ViewBag.Message = "You cannot access this survey";
            ViewBag.Title = "Survey submission not allowed";
            return View("SurveyExpired");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/survey/surveyresponse/{Id}/{email}")]
        public IActionResult SurveyResponse(List<AnswerViewModel> models, int surveyId, string email)
        {
            try
            {
                List<SurveySharedWithCustomers> flagUser = emailRepository.GetFlaggedUserData(surveyId);
                for (int i = 0; i < flagUser.Count; i++)
                {

                    if (email.Equals(flagUser[i].Email))
                    {
                        if (flagUser[i].HasSubmitted == false)
                        {
                            int srpId = repositorySRP.Insert(new SurveyResponseProfile { Id = 0, SurveyId = surveyId, FullName = "", ResponseOn = DateTime.Now });

                            foreach (var model in models)
                            {
                                var answer = model;
                                answer.SurveyResponseProfileId = srpId;
                                answer.AnswerText = String.IsNullOrWhiteSpace(answer.AnswerText) ? "" : answer.AnswerText;

                                if (model.Doc != null)
                                {
                                    answer.DocPath = fileService.Save(model.Doc);
                                }

                                repositoryAnswer.Insert(answer);

                            }
                            emailRepository.UpdateSubmitFlag(flagUser[i].ID, surveyId);
                            return View("SurveyCompleted");

                        }
                        else
                        {
                            ViewBag.Message = "You can submit the survey only once";
                            ViewBag.Title = "Survey already Submitted";
                            return View("SurveyExpired");
                        }
                    }
                }
                ViewBag.Message = "You are not allowed to view the suvey";
                ViewBag.Title = "Survey submission not allowed";
                return View("SurveyExpired");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IActionResult> Resubmit(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }

            var model = surveyRepository.GetByID(id);
            ViewBag.Departments = departmentRepository.GetAllDepartments();
            return View(model);
        }
        [HttpPost]
        public IActionResult Resubmit(Survey model)
        {
            var surveyEdited = surveyRepository.GetByID(model.Id);

            surveyEdited.IsRejected = false;
            surveyEdited.IsLaunched = false;
            surveyEdited.IsSubmitted = true;
            var result = surveyRepository.Update(surveyEdited);

            return RedirectToAction(nameof(Index));
        }

    }
}
