using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SV.Business.Interfaces;
using SV.Models.Entities;
using SV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Pollster")]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository repositoryQuestion;
        private readonly ISurveyRepository surveyRepository;
        private readonly UserManager<IdentityUser> userManager;

        public QuestionController(IQuestionRepository repositoryQuestion, ISurveyRepository surveyRepository, UserManager<IdentityUser> userManager)
        {
            this.repositoryQuestion = repositoryQuestion;
            this.surveyRepository = surveyRepository;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int surveyId)
        {
            ViewBag.ManageSurveyActive = "current";

            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                if (!surveyRepository.IsOwnOrShare(surveyId, user.Id))
                {
                    return NotFound();
                }
            }

            ViewBag.surveyId = surveyId;
            var parentChildQuestions = (await repositoryQuestion.GetBySurveyId(surveyId)).OrderBy(m=>m.Order).ToList();

            return View(parentChildQuestions);
        }

        public IActionResult Create(int? surveyId, int questionId = 0)
        {
            if (surveyId == null)
            {
                return View("~/views/shared/error.cshtml");
            }

            ViewBag.ManageSurveyActive = "current";

            if (questionId != 0)
            {
                var question = repositoryQuestion.GetByID(questionId);

                if (question == null || question.Type != "Logic" || string.IsNullOrEmpty(question.LogicalQuestionText))
                {
                    return View("~/views/shared/error.cshtml");
                }
            }

            var model = new Question { SurveyId = surveyId.Value, Id = questionId };
            model.Survey = surveyRepository.GetByID(surveyId.Value);

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Question model, string questionTextArabic, int surveyId)
        {
            if (model.Id != 0)
            {
                model.ParentQuestionId = model.Id;
                model.Id = 0;
            }

            if (!string.IsNullOrWhiteSpace(questionTextArabic))
            {
                model.QuestionText = string.Concat(model.QuestionText, "EQ_AQ_SP", questionTextArabic);
            }

            model.Order = repositoryQuestion.GetNewOrder(model.SurveyId);
            repositoryQuestion.Insert(model);
            var surveyModel = surveyRepository.GetByID(surveyId);
            surveyModel.IsRejected = false;
            surveyModel.IsLaunched = false;
            surveyModel.IsSubmitted = true;
            var result = surveyRepository.Update(surveyModel);
            return RedirectToAction(nameof(Index), new { surveyId = model.SurveyId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ManageSurveyActive = "current";

            var model = repositoryQuestion.GetByID(id);

            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(model.SurveyId, user.Id))
                {
                    return NotFound();
                }
            }

            model.Survey = surveyRepository.GetByID(model.SurveyId);

            if (model.Survey.Language == "Bilingual")
            {
                var strs = model.QuestionText.Split("EQ_AQ_SP").ToList();
                model.QuestionText = strs.ElementAtOrDefault(0);
                ViewData["questionTextArabic"] = strs.ElementAtOrDefault(1);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Question model, string questionTextArabic)
        {
            if (!string.IsNullOrWhiteSpace(questionTextArabic))
            {
                model.QuestionText = string.Concat(model.QuestionText, "EQ_AQ_SP", questionTextArabic);
            }

            repositoryQuestion.Update(model);
            return RedirectToAction(nameof(Index), new { surveyId = model.SurveyId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.ManageSurveyActive = "current";

            var model = repositoryQuestion.GetByID(id);
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(model.SurveyId, user.Id))
                {
                    return NotFound();
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Question model)
        {
            model = repositoryQuestion.GetByID(model.Id);

            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(model.SurveyId, user.Id))
                {
                    return NotFound();
                }
            }

            repositoryQuestion.Delete(model.Id);
            return RedirectToAction(nameof(Index), new { surveyId = model.SurveyId });
        }

        public async Task<IActionResult> Duplicate(int id)
        {
            var question = repositoryQuestion.GetByID(id);

            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(question.SurveyId, user.Id))
                {
                    return NotFound();
                }
            }

            var model = question;
            model.Id = 0;
            model.Order = repositoryQuestion.GetNewOrder(model.SurveyId);

            repositoryQuestion.Insert(model);

            return RedirectToAction(nameof(Index), new { surveyId = model.SurveyId });
        }

        public async Task<IActionResult> SetAnswer(int id)
        {
            ViewBag.ManageSurveyActive = "current";

            var question = repositoryQuestion.GetByID(id);
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(question.SurveyId, user.Id))
                {
                    return NotFound();
                }
            }

            var model = new OptionsViewModel(question);

            if (!string.IsNullOrEmpty(model.YesText))
            {
                model.YesText = model.YesText.Replace("Yes, ", " ");
            }
            if (!string.IsNullOrEmpty(model.NoText))
            {
                model.NoText = model.NoText.Replace("No, ", " ");
            }

            ViewBag.Language = surveyRepository.GetByID(question.SurveyId).Language;

            return View(model);
        }

        [HttpPost]
        public IActionResult SetAnswer(OptionsViewModel model)
        {
            string YesText = "Yes, ";
            string NoText = "No, ";
            var question = repositoryQuestion.GetByID(model.Question.Id);
            question.OptionsAlignment = model.Question.OptionsAlignment;
            question.CssClass = model.Question.CssClass;
            question.LogicalQuestionText = model.Question.LogicalQuestionText;


            if (question.Type == "Yes or No")
            {
                if (model.YesText == null)
                {
                    model.Question.OptionsText = string.Concat(model.YesText, "\n", NoText + model.NoText);
                }
                else if (model.NoText == null)
                {
                    model.Question.OptionsText = string.Concat(YesText + model.YesText, "\n", model.NoText);
                }
                else if (model.YesText == null && model.NoText == null)
                {
                    model.Question.OptionsText = string.Concat(model.YesText, "\n", model.NoText);
                }
                else if (!string.IsNullOrEmpty(model.YesText)  && !string.IsNullOrEmpty(model.NoText))
                {
                    model.Question.OptionsText = string.Concat(YesText + model.YesText, "\n", NoText + model.NoText);
                }

            }

            if (question.Type == "Net Promoter Score")
            {
                model.Question.OptionsText = string.Concat(model.MinText, "\n", model.MaxText);
            }

            if (question.Type == "Matrix Single" || question.Type == "Matrix Multi Select" || question.Type == "Semantic Question")
            {
                model.Question.OptionsText = string.Concat(model.MatrixHeader, "MH_MR_SP", model.MatrixRows);
            }

            question.OptionsText = model.Question.OptionsText;
            repositoryQuestion.Update(question);

            return RedirectToAction(nameof(Index), new { surveyId =  question.SurveyId});
        }

        public async Task<IActionResult> Order(int id)
        {
            ViewBag.ManageSurveyActive = "current";

            var models = await repositoryQuestion.GetParentBySurveyId(id);

            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(models.FirstOrDefault().SurveyId, user.Id))
                {
                    return NotFound();
                }
            }

            return View(models.OrderBy(x => x.Order).ToList());
        }

        [HttpPost]
        public IActionResult Order(IList<Question> models)
        {
            int surveyId = 0;

            for (int i = 0; i < models.Count(); i++)
            {
                var question = repositoryQuestion.GetByID(models[i].Id);
                question.Order = models[i].Order;
                repositoryQuestion.Update(question);
                surveyId = question.SurveyId;
            }

            return RedirectToAction(nameof(Index), new { surveyId = surveyId });
        }

        [HttpGet]
        public async Task<IActionResult> SaveResponseAsync(int id)
        {
            ViewBag.ManageSurveyActive = "current";

            var question = repositoryQuestion.GetByID(id);

            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(question.SurveyId, user.Id))
                {
                    return NotFound();
                }
            }

            var model = new OptionsViewModel(question);

            return View(model);
        }
    }
}
