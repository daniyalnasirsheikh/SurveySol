using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SV.Business.Interfaces;
using SV.Models.Entities;
using SV.Models.ViewModels;
using SV.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.WebApp.Controllers
{
    public class InactiveSurveyController : Controller
    {
        private readonly iUserDepartmentRepository userDepartmentRepository;
        private readonly iEmailRepository emailRepository;
        private readonly ISurveyRepository surveyRepository;
        private readonly iDepartmentRepository departmentRepository;
        private readonly iUserDepartmentRepository userdepartmentRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityUser> roleManager;
        private readonly IUserShareSurveyRepository userShareSurveyRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IConfiguration configuration;
        private readonly IRepository<Answer> repositoryAnswer;
        private readonly ISurveyResponseProfileRepository surveyResponseProfileRepository;
        private readonly IRepository<SurveyResponseProfile> repositorySRP;
        private readonly FileService fileService;


        public InactiveSurveyController(iEmailRepository emailRepository, iUserDepartmentRepository userdepartmentRepository, iDepartmentRepository departmentRepository, ISurveyRepository surveyRepository, UserManager<IdentityUser> userManager, IUserShareSurveyRepository userShareSurveyRepository,
            IQuestionRepository questionRepository, FileService fileService, ISurveyResponseProfileRepository surveyResponseProfileRepository, iUserDepartmentRepository userDepartmentRepository, IRepository<SurveyResponseProfile> repositorySRP)
        {
            this.userDepartmentRepository = userDepartmentRepository;
            this.departmentRepository = departmentRepository;
            this.surveyRepository = surveyRepository;
            this.userManager = userManager;
            this.userShareSurveyRepository = userShareSurveyRepository;
            this.questionRepository = questionRepository;
            this.configuration = configuration;
            this.surveyResponseProfileRepository = surveyResponseProfileRepository;
            this.userdepartmentRepository = userdepartmentRepository;
            this.emailRepository = emailRepository;
            this.fileService = fileService;
            this.repositorySRP = repositorySRP;
            this.repositoryAnswer = repositoryAnswer;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var roles = await userManager.GetRolesAsync(user);
            string UserRole = roles[0];
            string userDepartmentIds = userDepartmentRepository.GetUserDepartmentIDs(user.Id);
            List<Survey> submittedSurveys = surveyRepository.GetSubmittedSurveys(User.IsInRole("Admin"), user.Id, UserRole, userDepartmentIds);

            return View(submittedSurveys);
        }
        [HttpGet]
        public async Task<IActionResult> Launch(int id)
        {
            var model = surveyRepository.GetByID(id);
            ViewBag.SurveyName = model.Name;
            return View(model);
        }

        [HttpPost]
        public IActionResult Launch(Survey model)
        {
            var survey = surveyRepository.GetByID(model.Id);

            survey.StartDate = model.StartDate;
            survey.EndDate = model.EndDate;
            survey.IsLaunched = true;

            surveyRepository.Update(survey);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Reject(int id)
        {

            var survey = surveyRepository.GetByID(id);
            survey.StartDate = null;
            survey.EndDate = null;
            survey.IsLaunched = false;
            survey.IsRejected = true;
            survey.IsSubmitted = false;
            surveyRepository.Update(survey);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Preview(int id)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    var user = await userManager.FindByNameAsync(User.Identity.Name);

            //    if (!surveyRepository.IsOwnOrShare(id, user.Id))
            //    {
            //        return NotFound();
            //    }
            //}

            var survey = surveyRepository.GetByID(id);

            var questions = await questionRepository.GetBySurveyId(id);
            var model = new LauchSurveyViewModel(survey, questions);
            model.Options = model.Options.OrderBy(q => q.Question.Order).ToList();

            return View("Preview", model);
        }
        [HttpPost]
        public IActionResult Preview(List<AnswerViewModel> models, int surveyId)
        {
            return RedirectToAction("Index", "InactiveSurvey");
            //if (User.IsInRole("Reviewer"))
            //{

            //}
            //int srpId = repositorySRP.Insert(new SurveyResponseProfile { Id = 0, SurveyId = surveyId, FullName = "", ResponseOn = DateTime.Now });

            //foreach (var model in models)
            //{
            //    var answer = model;
            //    answer.SurveyResponseProfileId = srpId;
            //    answer.AnswerText = String.IsNullOrWhiteSpace(answer.AnswerText) ? "" : answer.AnswerText;

            //    if (model.Doc != null)
            //    {
            //        answer.DocPath = fileService.Save(model.Doc);
            //    }

            //    repositoryAnswer.Insert(answer);
            //}

            //return View("SurveyCompleted");
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

        
    }
}
