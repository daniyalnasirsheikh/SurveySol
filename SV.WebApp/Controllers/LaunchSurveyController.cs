using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SV.Business.Interfaces;
using SV.Models.Entities;
using SV.Models.Models;
using SV.Models.ViewModels;
using SV.WebApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SV.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Reviewer")]

    public class LaunchSurveyController : Controller
    {
        private readonly iUserDepartmentRepository userDepartmentRepository;
        private readonly iEmailRepository emailRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ISurveyRepository surveyRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly EmailService emailService;
        private readonly ISurveyResponseProfileRepository surveyResponseProfileRepository;
        private readonly IRepository<EmailTemplate> emailTempRepository;
        private URLConfig uRLConfig;

        public static int CurrentSurveyID;
        public static string uniqueSurveyURL;
        public static string surveyType;
        public LaunchSurveyController(IConfiguration configuration, UserManager<IdentityUser> userManager, ISurveyRepository surveyRepository, IQuestionRepository questionRepository, 
            EmailService emailService, ISurveyResponseProfileRepository surveyResponseProfileRepository, IRepository<EmailTemplate> emailTempRepository, iEmailRepository emailRepository, iUserDepartmentRepository userDepartmentRepository)
        {
            this.userDepartmentRepository = userDepartmentRepository;
            this.emailRepository = emailRepository;
            this.userManager = userManager;
            this.surveyRepository = surveyRepository;
            this.questionRepository = questionRepository;
            this.emailService = emailService;
            this.surveyResponseProfileRepository = surveyResponseProfileRepository;
            this.emailTempRepository = emailTempRepository;

            uRLConfig = new URLConfig();
            configuration.GetSection("ShareURL").Bind(uRLConfig);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.LaunchSurveyActive = "current";
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var roles = await userManager.GetRolesAsync(user);
            string UserRole = roles[0];
            string userDepartmentIds = userDepartmentRepository.GetUserDepartmentIDs(user.Id);
            var models = surveyRepository.GetAllLaunched(User.IsInRole("Admin"), user.Id, UserRole, userDepartmentIds);
            return View(models);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.LaunchSurveyActive = "current";
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var roles = await userManager. GetRolesAsync(user);
            string UserRole = roles[0];
            string userDepartmentIds = userDepartmentRepository.GetUserDepartmentIDs(user.Id);
            ViewBag.surveys = surveyRepository.GetAllUnPublish(User.IsInRole("Admin"), user.Id, UserRole, userDepartmentIds);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Survey model)
        {
            var survey = surveyRepository.GetByID(model.Id);
            
            survey.StartDate = model.StartDate;
            survey.EndDate = model.EndDate;
            survey.IsLaunched = true;

            surveyRepository.Update(survey);
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.LaunchSurveyActive = "current";

            //if (!User.IsInRole("Admin"))
            //{
            //    var user = await userManager.FindByNameAsync(User.Identity.Name);

            //    if (!surveyRepository.IsOwnOrShare(id, user.Id))
            //    {
            //        return NotFound();
            //    }
            //}

            var model = surveyRepository.GetByID(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Survey model)
        {
            //if (!User.IsInRole("Admin"))
            //{
            //    var user = await userManager.FindByNameAsync(User.Identity.Name);

            //    if (!surveyRepository.IsOwnOrShare(model.Id, user.Id))
            //    {
            //        return NotFound();
            //    }
            //}

            var survey = surveyRepository.GetByID(model.Id);

            survey.StartDate = model.StartDate;
            survey.EndDate = model.EndDate;

            surveyRepository.Update(survey);

            return RedirectToAction(nameof(Index));
        }  

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
  
            if (User.IsInRole("Reviewer") || User.IsInRole("Admin"))
            {
                var survey = surveyRepository.GetByID(id);
                survey.StartDate = null;
                survey.EndDate = null;
                survey.IsLaunched = false;

                surveyRepository.Update(survey);

                
            }

            return RedirectToAction(nameof(Index));
            //if (!User.IsInRole("Admin"))
            //{
            //    var user = await userManager.FindByNameAsync(User.Identity.Name);

            //    //if (!surveyRepository.IsOwnOrShare(id, user.Id))
            //    //{
            //    //    return NotFound();
            //    //}
            //}

            //var survey = surveyRepository.GetByID(id);
            //survey.StartDate = null;
            //survey.EndDate = null;
            //survey.IsLaunched = false;

            //surveyRepository.Update(survey);

            //return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShareSurvey(int id)
        {
            try
            {
                CurrentSurveyID = id;
                ViewBag.LaunchSurveyActive = "current";
                Survey currentSurvey = surveyRepository.GetSurveyByID(id);
                surveyType = currentSurvey.SurveyType;
                //if (!User.IsInRole("Admin"))
                //{
                //    var user = await userManager.FindByNameAsync(User.Identity.Name);

                //    if (!surveyRepository.IsOwnOrShare(id, user.Id))
                //    {
                //        return NotFound();
                //    }
                //}
                ViewBag.SurveyType = surveyType;
                string surveyURL = uRLConfig.URL + "survey/surveyresponse/" + id;

                uniqueSurveyURL = surveyURL;

                //Uri myUri = new Uri(uniqueSurveyURL);

                string TinyURL = surveyRepository.GenerateTinyURL(surveyURL);

                ViewBag.URL = TinyURL;
                
                var model = new SurveySendViewModel { Url = TinyURL };
                
                return View(model);


            }
            catch (Exception ex)
            {

                var model =  new SurveySendViewModel { ErrorMessage = ex.Message };
                return View(model);
            }
                
        }

        [HttpPost]
        public IActionResult ShareSurvey(SurveySendViewModel model)
        {
            
            ViewBag.LaunchSurveyActive = "current";
            ViewBag.SurveyType = surveyType;
            if (surveyType == "OPEN")
            {
                try
                {
                    var emails = model.EmailText.Split("\n").ToList();

                    List<MailAddress> addresses = new List<MailAddress>();

                    foreach (var email in emails)
                    {
                        var strs = email.Split(",");
                        addresses.Add(new MailAddress(strs.ElementAtOrDefault(1).Trim(), strs.ElementAtOrDefault(0).Trim()));
                    }
                    foreach (var address in addresses)
                    {
                        emailService.SendWithSMTP(address, model.Url);
                    }

                    model.SuccessMessage = "Email sent successfully.";
                }
                catch (Exception ex)
                {
                    model.ErrorMessage = ex.Message;
                }
            }

            else
            {
                if (model.medium.ToLower().Equals("sms"))
                {
                    try
                    {
                        List<SurveySharedWithCustomers> emailListObj = new List<SurveySharedWithCustomers>();
                        string uniqueGeneratedTinyURL;
                        string contactNumber;
                        int parseResult = 0;
                        List<string> lstCustomerDetails = model.EmailText.Split("\n").ToList();
                        List<string> lstContactNumber = new List<string>();
                        
                        lstContactNumber.AddRange(lstCustomerDetails.Select(e => e.Trim().Split(",").Last()));
                        //bool testr = int.TryParse(lstContactNumber[0], out parseResult);
                        IEnumerable<bool> isParsed = lstContactNumber.Select(n => int.TryParse(n, out parseResult));
                        if (isParsed.Contains(false))
                        {
                            model.ErrorMessage = "Only Numbers are allowed with names when 'By SMS' option is selected";
                            return View(model);
                        }
                        List<MailAddress> addresses = new List<MailAddress>();

                        for (int i = 0; i < lstContactNumber.Count; i++)
                        {
                            uniqueGeneratedTinyURL = uniqueSurveyURL + "/" + lstContactNumber[i];

                            uniqueGeneratedTinyURL = surveyRepository.GenerateTinyURL(uniqueGeneratedTinyURL);
                            emailListObj.Add(new SurveySharedWithCustomers
                            {
                                SurveyID = CurrentSurveyID,
                                Email = lstContactNumber[i],
                                ContactNumber = lstContactNumber[i],
                                HasSubmitted = false,
                                UniqueSurveyURL = uniqueGeneratedTinyURL
                            });
                        }

                        emailRepository.InsertEmails(emailListObj);
                        return Excel(emailListObj);
                    }
                    catch (Exception ex)
                    {
                        model.ErrorMessage = ex.Message;
                    }
                }
                else
                {
                    try
                    {
                        List<SurveySharedWithCustomers> emailListObj = new List<SurveySharedWithCustomers>();
                        string uniqueGeneratedTinyURL;
                        string number;
                        string email;
                        List<string> customerEmail = new List<string>();
                        List<string> emails = model.EmailText.Trim().Split("\n").ToList();

                        customerEmail.AddRange(emails.Select(e => e.Trim().Split(",").Last()));
                        if (customerEmail.Contains("") || customerEmail.Contains(null))
                        {
                            model.ErrorMessage = "Email not provided";
                            return View(model);
                        }

                        List<MailAddress> addresses = new List<MailAddress>();

                        foreach (var e in emails)
                        {
                            var strs = e.Trim().Split(",");
                            addresses.Add(new MailAddress(strs.ElementAtOrDefault(1).Trim(), strs.ElementAtOrDefault(0).Trim()));
                        }

                        for (int i = 0; i < addresses.Count; i++)
                        {
                            uniqueGeneratedTinyURL = uniqueSurveyURL + "/" + addresses[i].Address;
                            // Uri myUri = new Uri(uniqueGeneratedTinyURL);

                            uniqueGeneratedTinyURL = surveyRepository.GenerateTinyURL(uniqueGeneratedTinyURL);
                            emailListObj.Add(new SurveySharedWithCustomers
                            {
                                SurveyID = CurrentSurveyID,
                                Email = addresses[i].Address,
                                ContactNumber = customerEmail[i],
                                HasSubmitted = false,
                                UniqueSurveyURL = uniqueGeneratedTinyURL
                            });
                        }

                        emailRepository.InsertEmails(emailListObj);
                        foreach (var address in addresses)
                        {
                            uniqueGeneratedTinyURL = uniqueSurveyURL + "/" + address.Address;
                            //Uri myUri = new Uri(uniqueGeneratedTinyURL);
                            uniqueGeneratedTinyURL = surveyRepository.GenerateTinyURL(uniqueGeneratedTinyURL);
                            //emailService.Send(address, model.Url);
                            emailService.SendWithSMTP(address, uniqueGeneratedTinyURL);
                        }

                        model.SuccessMessage = "Email sent successfully.";
                    }
                    catch (Exception ex)
                    {
                        model.ErrorMessage = ex.Message;
                    }
                }
            }
            return View(model);
        }

        public ActionResult DeletePreviousReponses(int id)
        {
            var survey = surveyRepository.GetByID(id);
            return View(survey);
        }

        [HttpPost]
        public ActionResult DeletePreviousReponses(Survey survey)
        {
            surveyResponseProfileRepository.DeleteResponsesBySurveyId(survey.Id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult EditTemplate()
        {
            var model = emailTempRepository.GetByID(1);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTemplate(EmailTemplate model)
        {
            var emailTemp = emailTempRepository.GetByID(1);
            emailTemp.SenderName = model.SenderName;
            emailTemp.Subject = model.Subject;
            emailTemp.Body = model.Body;

            var result = emailTempRepository.Update(emailTemp);
            
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Excel(List<SurveySharedWithCustomers> objCustomer)
        {
            System.IO.Stream spreadsheetStream = new System.IO.MemoryStream();
            XLWorkbook workbook = new XLWorkbook();
             
            workbook.AddWorksheet("Survey");
            var ws = workbook.Worksheet("Survey");

            int row = 2;
            ws.Cell("A" + "1").Value = "PhoneNo";
            ws.Cell("B" + "1").Value = "Message";
            
            foreach (var c in objCustomer)
            {
                string test = $"";
                ws.Cell("A" + row.ToString()).Value = c.ContactNumber + Environment.NewLine;
                ws.Cell("B" + row.ToString()).Value = string.Format("Thank you for banking with us. We would appreciate your efforts in completing this survey to help us improve our services."+ Environment.NewLine + c.UniqueSurveyURL);
                
                row++;  
            }
            ws.Column("A").AdjustToContents();
            ws.Column("B").AdjustToContents();

            string filename = $"Customer SMS List-{DateTime.Now.ToString("M-dd-yyyy-T-H_m_ss")}.xlsx";
            //workbook.SaveAs(@"E:\Enum Solutions\"+ filename);

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        filename
                        );

            }
            //spreadsheetStream.Position = 0;
            //return new FileStreamResult(spreadsheetStream, "application/vnd.ms-excel") { FileDownloadName = filename };
            
        }
        
    }
}
