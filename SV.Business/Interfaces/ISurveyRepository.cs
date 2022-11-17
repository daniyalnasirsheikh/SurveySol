using SV.Models.Entities;
using SV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Business.Interfaces
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        public string GenerateTinyURL(string originalPath);
        public List<Survey> GetLatestCreatedSurvey(bool isAdmin, string userId);
        List<Survey> GetAll(bool isAdmin, string userId);
        List<Survey> GetAllPublish(bool isAdmin, string userId);
        List<Survey> GetAllUnPublish(bool isAdmin, string userId, string role, string departmentIds);
        bool IsOwnOrShare(int surveyId, string userId);
        List<Survey> GetMySurveyStatistics(string userId);
        int GetAllCount();
        int GetAllPublishCount();
        int GetAllUnPublishCount();
        int GetAllCloseCount();
        public Survey GetSurveyByID(int surveyID);
        public List<Survey> GetSubmittedSurveys(bool isAdmin, string userId, string role, string userDepartmentIds);
        public List<Survey> GetAllLaunched(bool isAdmin, string userId, string role, string userDepartmentIds);
    }
}
