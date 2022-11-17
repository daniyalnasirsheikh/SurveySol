using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using SV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SV.Business.Implementation
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(SVDBContext context) : base(context)
        {
        }

        public string GenerateTinyURL(string originalPath)
        {
            try
            {

                string URL = "https://tinyurl.com/api-create.php?url=" + originalPath;

                //Uri myUri = new Uri(URL);
                System.Net.HttpWebRequest objWebRequest;
                System.Net.HttpWebResponse objWebResponse;
                
                System.IO.StreamReader srReader;

                string strHTML;

                objWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
                objWebRequest.Method = "GET";
                objWebRequest.Timeout = 180000;
                objWebResponse = (System.Net.HttpWebResponse)objWebRequest.GetResponse();
                srReader = new System.IO.StreamReader(objWebResponse.GetResponseStream());

                strHTML = srReader.ReadToEnd();

                srReader.Close();
                objWebResponse.Close();
                objWebRequest.Abort();
                return strHTML;
            }
            catch
            {

                throw;
            }

        }

        public List<Survey> GetLatestCreatedSurvey(bool isAdmin, string userId)
        {
            var output = new List<Survey>();

            if (isAdmin)
            {

                output = DBSet.OrderByDescending(x => x.Id).Take(1).ToList();
            }
            else
            {
                var ownSurveys = DBSet.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).Take(1).ToList();
                output.AddRange(ownSurveys);
                var sharedSurveys = DBSet.Where(x => x.UserShareSurveys.Any(u => u.UserId == userId)).OrderByDescending(x => x.Id).Take(1).ToList();
                output.AddRange(sharedSurveys);
            }

            return ProcessSurveys(output);
        }

        public List<Survey> GetAll(bool isAdmin, string userId)
        {
            var output = new List<Survey>();

            if (isAdmin)
            {
                output = DBSet.ToList();
            }
            else
            {
                var ownSurveys = DBSet.Where(x => x.UserId == userId).ToList();
                output.AddRange(ownSurveys);
                var sharedSurveys = DBSet.Where(x => x.UserShareSurveys.Any(u => u.UserId == userId)).ToList();
                output.AddRange(sharedSurveys);
            }

            return ProcessSurveys(output);
        }

        public List<Survey> GetAllPublish(bool isAdmin, string userId)
        {
            var output = new List<Survey>();

            if (isAdmin)
            {
                output = DBSet.Where(x => x.IsLaunched == true).ToList();
            }
            else
            {
                var ownSurveys = DBSet.Where(x => x.UserId == userId && x.IsLaunched == true).ToList();
                output.AddRange(ownSurveys);
                var sharedSurveys = DBSet.Where(x => x.IsLaunched == true && x.UserShareSurveys.Any(u => u.UserId == userId)).ToList();
                output.AddRange(sharedSurveys);
            }

            return output;
        }
        public List<Survey> GetAllLaunched(bool isAdmin, string userId, string role, string userDepartmentIds)
        {
            var output = new List<Survey>();

            if (isAdmin)
            {
                output = DBSet.Where(x => x.IsLaunched == true).ToList();
            }
            else
            {
                var ownSurveys = DBSet.Where(x => x.UserId == userId && x.IsLaunched == true).ToList();
                output.AddRange(ownSurveys);
                var sharedSurveys = DBSet.Where(x => x.IsLaunched == true && x.UserShareSurveys.Any(u => u.UserId == userId)).ToList();
                output.AddRange(sharedSurveys);

                List<string> userDepartmentIdsList = userDepartmentIds.Split(',').ToList();
                foreach (var item in userDepartmentIdsList)
                {
                    var departmentRelatedSurveys = DBSet.Where(x => x.IsLaunched == true && x.DepartmentIds.Contains(item));
                    output.AddRange(departmentRelatedSurveys);
                }
                HashSet<Survey> uniqueSurveys = new HashSet<Survey>();
                foreach (var item in output)
                {
                    uniqueSurveys.Add(item);
                }
                output = uniqueSurveys.ToList();
            }

            return output;
        }

        public List<Survey> GetMySurveyStatistics(string userId)
        {
            var surveys = DBSet.Where(x => x.UserId == userId).OrderByDescending(m=>m.Id).Take(5).ToList();
            return surveys;
        }

        public List<Survey> GetAllUnPublish(bool isAdmin, string userId, string role, string userDepartmentIds)
        {
            var output = new List<Survey>();

            if (isAdmin)
            {
                output = DBSet.Where(x => x.IsLaunched == false).ToList();
            }
            else
            {
                if (role.Equals("Reviewer"))
                {
                    List<string> userDepartmentIdsList = userDepartmentIds.Split(',').ToList();
                    foreach (var item in userDepartmentIdsList)
                    {
                        var departmentRelatedSurveys = DBSet.Where(x => x.IsLaunched == false && x.DepartmentIds.Contains(item));
                        output.AddRange(departmentRelatedSurveys);
                    }

                }
                var ownSurveys = DBSet.Where(x => x.UserId == userId && x.IsLaunched == false).ToList();
                output.AddRange(ownSurveys);
                var sharedSurveys = DBSet.Where(x => x.IsLaunched == false && x.UserShareSurveys.Any(u => u.UserId == userId)).ToList();
                output.AddRange(sharedSurveys);
            }
            List<Survey> distinctSurveys = output.Distinct().ToList();
            return distinctSurveys;
        }

        public bool IsOwnOrShare(int surveyId, string userId)
        {
            bool output = false;

            var survey = DBSet.FirstOrDefault(x => x.Id == surveyId && x.UserId == userId);

            if (survey != null)
            {
                output = true;
            }

            var shareSurvey = DBSet.FirstOrDefault(x => x.UserShareSurveys.Any(u => u.SurveyId == surveyId && u.UserId == userId));

            if (shareSurvey != null)
            {
                output = true;
            }

            return output;
        }

        public Survey ProcessSurvey(Survey survey)
        {
            if (survey != null)
            {

                if (survey.IsLaunched)
                {
                    survey.DetailedName = survey.Name + " - Launched";
                }
                else
                {
                    survey.DetailedName = survey.Name + " - Not Launched";
                }
            }

            return survey;
        }

        public List<Survey> ProcessSurveys(List<Survey> surveys)
        {
            if (surveys != null && surveys.Count > 0)
            {
                foreach (var sv in surveys)
                {
                    if (sv.IsLaunched)
                    {
                        sv.DetailedName = sv.Name + " - Launched";
                    }
                    else
                    {
                        sv.DetailedName = sv.Name + " - Not Launched";
                    }
                }
            }

            return surveys;
        }

        public int GetAllCount()
        {
            return DBSet.Count();
        }

        public int GetAllPublishCount()
        {
            return DBSet.Where(x => x.IsLaunched == true).Count();
        }

        public int GetAllUnPublishCount()
        {
            return DBSet.Where(x => x.IsLaunched == false).Count();
        }

        public int GetAllCloseCount()
        {
            return DBSet.Where(x => x.EndDate < DateTime.Now).Count();
        }

        public Survey GetSurveyByID(int surveyID)
        {
            return DBSet.Where(x => x.Id == surveyID).FirstOrDefault();
        }

        public List<Survey> GetSubmittedSurveys(bool isAdmin, string userId, string role, string userDepartmentIds)
        {
            var output = new List<Survey>();

            if (isAdmin)
            {
                output = DBSet.Where(x => x.IsLaunched == false && x.IsRejected.Equals(false) && x.IsSubmitted.Equals(true)).ToList();
            }
            else
            {
                if (role.Equals("Reviewer"))
                {
                    List<string> userDepartmentIdsList = userDepartmentIds.Split(',').ToList();
                    foreach (var item in userDepartmentIdsList)
                    {
                        var departmentRelatedSurveys = DBSet.Where(x => x.IsLaunched == false && x.IsRejected.Equals(false) && x.IsSubmitted.Equals(true) && x.DepartmentIds.Contains(item));
                        output.AddRange(departmentRelatedSurveys);
                    }

                }
                var ownSurveys = DBSet.Where(x => x.UserId == userId && x.IsLaunched == false).ToList();
                output.AddRange(ownSurveys);
                var sharedSurveys = DBSet.Where(x => x.IsLaunched == false && x.IsRejected.Equals(false) && x.IsSubmitted.Equals(true) && x.UserShareSurveys.Any(u => u.UserId == userId)).ToList();
                output.AddRange(sharedSurveys);
            }
            List<Survey> distinctSurveys = output.Distinct().ToList();
            return distinctSurveys;
        }
    }
}
