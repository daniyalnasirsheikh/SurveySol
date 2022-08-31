using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SV.Business.Interfaces
{
    public interface IQuestionRepository: IRepository<Question>
    {
        Task<List<Question>> GetBySurveyId(int surveyId);
        Task<List<Question>> GetWithAnswerBySurveyId(int surveyId);
        Task<List<Question>> GetParentBySurveyId(int surveyId);
        Task<List<Question>> GetChildByParentQuestionId(int questionId);
        Task<List<Question>> GetByPage(int surveyId, int skip, int take);
        int GetNewOrder(int surveyId);
        Task<Question> GetWithAnswerById(int questionId);
    }
}
