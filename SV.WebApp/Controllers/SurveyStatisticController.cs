using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SV.Business.Interfaces;
using SV.Models.Entities;
using SV.Models.ViewModels;
using SV.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Pollster,Reviewer")]
    public class SurveyStatisticController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ISurveyRepository surveyRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IRepository<SurveyResponseProfile> srpRepository;
        private readonly IAnswerRepository answerRepository;
        private readonly ISurveyResponseProfileRepository repositorySRP;

        public SurveyStatisticController(UserManager<IdentityUser> userManager, ISurveyRepository surveyRepository, IQuestionRepository questionRepository, 
            IRepository<SurveyResponseProfile> srpRepository, IAnswerRepository answerRepository, ISurveyResponseProfileRepository repositorySRP)
        {
            this.userManager = userManager;
            this.surveyRepository = surveyRepository;
            this.questionRepository = questionRepository;
            this.srpRepository = srpRepository;
            this.answerRepository = answerRepository;
            this.repositorySRP = repositorySRP;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SurveyStatisticsActive = "current";
            //var surveys = surveyRepository.GetAll(User.IsInRole("Admin"), user.Id);
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var surveys = surveyRepository.GetAllPublish(User.IsInRole("Admin"), user.Id);
            return View(surveys);
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.SurveyStatisticsActive = "current";

            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }

            return View(new Survey());
        }

        // id is survey reponse profile id
        public async Task<IActionResult> Preview(int id)
        {
            var srp = srpRepository.GetByID(id);
            var answers = answerRepository.GetAll(id);
            var survey = surveyRepository.GetByID(srp.SurveyId);

            var questions = await questionRepository.GetBySurveyId(srp.SurveyId);
            var model = new LauchSurveyViewModel(survey, questions);

            foreach (var option in model.Options)
            {
                option.Answer = answers.Where(x => x.QuestionId == option.Question.Id).FirstOrDefault();

                if (option.Answer == null)
                {
                    option.Answer = new Answer();
                }
            }

            model.Options = model.Options.OrderBy(q => q.Question.Order).ToList();

            return View(model);
        }

        public IActionResult Statistics(int id)
        {
            ViewBag.SurveyStatisticsActive = "current";

            return View(new List<Answer>());
        }

        public async Task<IActionResult> Responses(int id)
        {
            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }

            Survey survey = surveyRepository.GetByID(id);

            if (survey == null)
            {
                return NotFound();
            }

            ViewBag.Survey = survey;
            List<SurveyResponseProfile> responseProfiles = await repositorySRP.GetBySurveyId(id);
            return PartialView("_Responses", responseProfiles);
        }

        public async Task<IActionResult> Dashboard(int id)
        {
            ViewBag.SurveyStatisticsActive = "current";

            if (!User.IsInRole("Admin"))
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                if (!surveyRepository.IsOwnOrShare(id, user.Id))
                {
                    return NotFound();
                }
            }

            Survey survey = surveyRepository.GetByID(id);

            if (survey == null)
            {
                return NotFound();
            }

            ViewBag.Survey = survey;
            List<Question> questions = await questionRepository.GetWithAnswerBySurveyId(id);

            if (questions != null && questions.Count > 0)
            {
                foreach (var question in questions)
                {
                    if (survey.Language == "Bilingual")
                    {
                        var strs = question.QuestionText.Split("EQ_AQ_SP").ToList();
                        question.QuestionText = strs.ElementAtOrDefault(0);
                        question.QuestionTextArabic = strs.ElementAtOrDefault(1);
                    }

                    question.OptionsViewModel = new OptionsViewModel(question);

                    if (question.Type == "Rating")
                    {
                        double terrible = 0, bad = 0, okay = 0, good = 0, great = 0, sum = 0;

                        terrible = question.Answers.Where(m => m.AnswerText == "1").Count();
                        bad = question.Answers.Where(m => m.AnswerText == "2").Count();
                        okay = question.Answers.Where(m => m.AnswerText == "3").Count();
                        good = question.Answers.Where(m => m.AnswerText == "4").Count();
                        great = question.Answers.Where(m => m.AnswerText == "5").Count();

                        sum = terrible + bad + okay + good + great;

                        question.RatingTerriblePer = Math.Round((terrible / sum) * 100, 2);
                        question.RatingBadPer = Math.Round((bad / sum) * 100, 2);
                        question.RatingOkayPer = Math.Round((okay / sum) * 100, 2);
                        question.RatingGoodPer = Math.Round((good / sum) * 100, 2);
                        question.RatingGreatPer = Math.Round((great / sum) * 100, 2);
                    }
                    else if (question.Type == "Radio" || question.Type == "Dropdown Menu" || question.Type == "Multiple Choice" || question.Type == "Logic")
                    {
                        if (question.OptionsViewModel != null && question.OptionsViewModel.Options.Count > 0)
                        {
                            double sum = 0;
                            foreach (var answer in question.OptionsViewModel.Options)
                            {
                                int totalAnswersCount = 0;
                                if (question.Type == "Multiple Choice")
                                {
                                    totalAnswersCount = question.Answers.Where(m => m.AnswerText.Contains(answer)).Count();
                                }
                                else
                                {
                                    totalAnswersCount = question.Answers.Where(m => m.AnswerText.Equals(answer)).Count();
                                }
                                
                                question.KeyValuePair.Add(answer, totalAnswersCount);

                                sum += totalAnswersCount;
                            }

                            if (question.KeyValuePair != null && question.KeyValuePair.Count > 0)
                            {
                                foreach (var kvp in question.KeyValuePair.ToArray())
                                    question.KeyValuePair[kvp.Key] = Math.Round((kvp.Value / sum) * 100, 2);

                            }
                        }
                    }
                    else if (question.Type == "Yes or No")
                    {
                        
                        int totalYesAnswersCount = question.Answers.Where(m => m.AnswerText.Contains(question.OptionsViewModel.YesText)).Count();
                        int totalNoAnswersCount = question.Answers.Where(m => m.AnswerText.Contains(question.OptionsViewModel.NoText)).Count();
                        double sum = totalYesAnswersCount + totalNoAnswersCount;

                        question.KeyValuePair.Add(question.OptionsViewModel.YesText, Math.Round((totalYesAnswersCount / sum) * 100, 2));
                        question.KeyValuePair.Add(question.OptionsViewModel.NoText, Math.Round((totalNoAnswersCount / sum) * 100, 2));
                    }
                    else if (question.Type == "Net Promoter Score")
                    {

                        int dissatisfiedCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) >= 0 & Convert.ToInt32(m.AnswerText) <= 4).Count();
                        int neutralCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) == 5).Count();
                        int satisfiedCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) >= 6 & Convert.ToInt32(m.AnswerText) <= 7).Count();
                        int verySatisfiedCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) >= 8 & Convert.ToInt32(m.AnswerText) <= 10).Count();
                        double sum = dissatisfiedCount + neutralCount + satisfiedCount + verySatisfiedCount;

                        double vs = Math.Round((verySatisfiedCount / sum) * 100, 2);
                        double s = Math.Round((satisfiedCount / sum) * 100, 2);
                        double n = Math.Round((neutralCount / sum) * 100, 2);
                        double ds = Math.Round((dissatisfiedCount / sum) * 100, 2);
                        double np = ((vs + s) - (n + ds)); 

                        question.KeyValuePair.Add("Very Satisfied", vs);
                        question.KeyValuePair.Add("Satisfied", s);
                        question.KeyValuePair.Add("Neutral", n);
                        question.KeyValuePair.Add("Dissatisfied", ds);
                        question.KeyValuePair.Add("Net Promoters", np);
                    }
                    else if (question.Type == "Matrix Single" || question.Type == "Matrix Multi Select" || question.Type == "Semantic Question")
                    {
                        int totalRows = question.OptionsViewModel.MatrixRowsOptions.Count;
                        int totalCols = question.OptionsViewModel.MatrixHeaderOptions.Count;

                        question.MatrixArray = new double[totalRows,totalCols];
                        double sum = 0;

                        for (int row = 0; row < totalRows; row++)
                        {
                            for (int col = 0; col < totalCols; col++)
                            {
                                string answerToSearch = question.OptionsViewModel.MatrixRowsOptions[row].Trim().Replace("\r", "") 
                                    + "," 
                                    + question.OptionsViewModel.MatrixHeaderOptions[col].Trim().Replace("\r", "");

                                int totalCount = 0;

                                if (question.Type == "Semantic Question" || question.Type == "Matrix Multi Select")
                                {
                                    totalCount = question.Answers.Where(m => m.AnswerText.Contains(answerToSearch)).Count();
                                }
                                else
                                {
                                    totalCount = question.Answers.Where(m => m.AnswerText.Equals(answerToSearch)).Count();
                                }
                                
                                question.MatrixArray[row, col] = totalCount;
                                sum += totalCount;
                            }
                        }

                        // calculating percentage 

                        for (int row = 0; row < totalRows; row++)
                        {
                            for (int col = 0; col < totalCols; col++)
                            {
                                double totalCount = question.MatrixArray[row, col];
                                question.MatrixArray[row, col] = Math.Round((totalCount / sum) * 100, 2);
                            }
                        }
                    }
                }
            }

            List<SurveyResponseProfile> responseProfiles = await repositorySRP.GetBySurveyId(id);
            return View(questions);
        }

        public async Task<IActionResult> Chart(int chartType, int questionId)
        {
            Question question = await questionRepository.GetWithAnswerById(questionId);

            if (question != null)
            {
                question.OptionsViewModel = new OptionsViewModel(question);

                if (question.Type == "Radio" || question.Type == "Dropdown Menu" || question.Type == "Multiple Choice" || question.Type == "Logic")
                {
                    if (question.OptionsViewModel != null && question.OptionsViewModel.Options.Count > 0)
                    {
                        double sum = 0;
                        foreach (var answer in question.OptionsViewModel.Options)
                        {
                            int totalAnswersCount = 0;
                            if (question.Type == "Multiple Choice")
                            {
                                totalAnswersCount = question.Answers.Where(m => m.AnswerText.Contains(answer)).Count();
                            }
                            else
                            {
                                totalAnswersCount = question.Answers.Where(m => m.AnswerText.Equals(answer)).Count();
                            }

                            question.KeyValuePair.Add(answer, totalAnswersCount);

                            sum += totalAnswersCount;
                        }

                        if (question.KeyValuePair != null && question.KeyValuePair.Count > 0)
                        {
                            foreach (var kvp in question.KeyValuePair.ToArray())
                                question.KeyValuePair[kvp.Key] = Math.Round((kvp.Value / sum) * 100, 2);

                        }
                    }
                }
                else if (question.Type == "Yes or No")
                {

                    int totalYesAnswersCount = question.Answers.Where(m => m.AnswerText.Contains(question.OptionsViewModel.YesText)).Count();
                    int totalNoAnswersCount = question.Answers.Where(m => m.AnswerText.Contains(question.OptionsViewModel.NoText)).Count();
                    double sum = totalYesAnswersCount + totalNoAnswersCount;

                    question.KeyValuePair.Add(question.OptionsViewModel.YesText, Math.Round((totalYesAnswersCount / sum) * 100, 2));
                    question.KeyValuePair.Add(question.OptionsViewModel.NoText, Math.Round((totalNoAnswersCount / sum) * 100, 2));
                }
                else if (question.Type == "Net Promoter Score")
                {

                    //int demotivatorsCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) >= 0 & Convert.ToInt32(m.AnswerText) <= 4).Count();
                    //int neutralCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) == 5).Count();
                    //int promotersCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) >= 6 & Convert.ToInt32(m.AnswerText) <= 10).Count();
                    //double sum = demotivatorsCount + neutralCount + promotersCount;

                    //question.KeyValuePair.Add("Demotivators", Math.Round((demotivatorsCount / sum) * 100, 2));
                    //question.KeyValuePair.Add("Neutral", Math.Round((neutralCount / sum) * 100, 2));
                    //question.KeyValuePair.Add("Promoters", Math.Round((promotersCount / sum) * 100, 2));

                    int dissatisfiedCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) >= 0 & Convert.ToInt32(m.AnswerText) <= 4).Count();
                    int neutralCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) == 5).Count();
                    int satisfiedCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) >= 6 & Convert.ToInt32(m.AnswerText) <= 7).Count();
                    int verySatisfiedCount = question.Answers.Where(m => Convert.ToInt32(m.AnswerText) >= 8 & Convert.ToInt32(m.AnswerText) <= 10).Count();
                    double sum = dissatisfiedCount + neutralCount + satisfiedCount + verySatisfiedCount;

                    double vs = Math.Round((verySatisfiedCount / sum) * 100, 2);
                    double s = Math.Round((satisfiedCount / sum) * 100, 2);
                    double n = Math.Round((neutralCount / sum) * 100, 2);
                    double ds = Math.Round((dissatisfiedCount / sum) * 100, 2);

                    question.KeyValuePair.Add("Very Satisfied", vs);
                    question.KeyValuePair.Add("Satisfied", s);
                    question.KeyValuePair.Add("Neutral", n);
                    question.KeyValuePair.Add("Dissatisfied", ds);
                }
                else if (question.Type == "Rating")
                {
                    double terrible = 0, bad = 0, okay = 0, good = 0, great = 0, sum = 0;

                    terrible = question.Answers.Where(m => m.AnswerText == "1").Count();
                    bad = question.Answers.Where(m => m.AnswerText == "2").Count();
                    okay = question.Answers.Where(m => m.AnswerText == "3").Count();
                    good = question.Answers.Where(m => m.AnswerText == "4").Count();
                    great = question.Answers.Where(m => m.AnswerText == "5").Count();

                    sum = terrible + bad + okay + good + great;

                    question.KeyValuePair.Add("Terrible", Math.Round((terrible / sum) * 100, 2));
                    question.KeyValuePair.Add("Bad", Math.Round((bad / sum) * 100, 2));
                    question.KeyValuePair.Add("Okay", Math.Round((okay / sum) * 100, 2));
                    question.KeyValuePair.Add("Good", Math.Round((good / sum) * 100, 2));
                    question.KeyValuePair.Add("Great", Math.Round((great / sum) * 100, 2));
                }
                else if (question.Type == "Matrix Single" || question.Type == "Matrix Multi Select" || question.Type == "Semantic Question")
                {
                    int totalRows = question.OptionsViewModel.MatrixRowsOptions.Count;
                    int totalCols = question.OptionsViewModel.MatrixHeaderOptions.Count;

                    question.MatrixArray = new double[totalRows, totalCols];
                    double sum = 0;

                    for (int row = 0; row < totalRows; row++)
                    {
                        for (int col = 0; col < totalCols; col++)
                        {
                            string answerToSearch = question.OptionsViewModel.MatrixRowsOptions[row].Trim().Replace("\r", "")
                                + ","
                                + question.OptionsViewModel.MatrixHeaderOptions[col].Trim().Replace("\r", "");

                            int totalCount = 0;

                            if (question.Type == "Semantic Question" || question.Type == "Matrix Multi Select")
                            {
                                totalCount = question.Answers.Where(m => m.AnswerText.Contains(answerToSearch)).Count();
                            }
                            else
                            {
                                totalCount = question.Answers.Where(m => m.AnswerText.Equals(answerToSearch)).Count();
                            }

                            question.MatrixArray[row, col] = totalCount;
                            sum += totalCount;
                        }
                    }

                    // calculating percentage 

                    for (int row = 0; row < totalRows; row++)
                    {
                        for (int col = 0; col < totalCols; col++)
                        {
                            double totalCount = question.MatrixArray[row, col];
                            question.KeyValuePair.Add(question.OptionsViewModel.MatrixRowsOptions[row] + ", " + question.OptionsViewModel.MatrixHeaderOptions[col], Math.Round((totalCount / sum) * 100, 2));
                        }
                    }
                }
            }

            ViewBag.ChartType = chartType;
            ViewBag.QuestionType = question.Type;

            return PartialView("_Chart", question);
        }
    }
}
