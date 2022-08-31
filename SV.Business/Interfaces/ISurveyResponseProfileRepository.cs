using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SV.Business.Interfaces
{
    public interface ISurveyResponseProfileRepository : IRepository<SurveyResponseProfile> 
    {
        Task<List<SurveyResponseProfile>> GetBySurveyId(int surveyId);
        Task<List<SurveyResponseProfile>> GetLatestFiveResponsesByUserId(string userId);
        int TotalResponses(int surveyId);
        void DeleteResponsesBySurveyId(int surveyId);
    }
}
