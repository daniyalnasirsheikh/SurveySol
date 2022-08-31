using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SV.Business.Interfaces
{
    public interface IUserShareSurveyRepository : IRepository<UserShareSurvey>
    {
        Task<List<UserShareSurvey>> GetBySurveyId(int surveyId);
        Task<bool> Save(List<UserShareSurvey> userShareSurveys);
    }
}
