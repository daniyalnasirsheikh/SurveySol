using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Business.Implementation
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(SVDBContext context) : base(context)
        {

        }

        public Task<List<Question>> GetByPage(int surveyId, int skip, int take)
        {
            var models = DBSet.Where(x => x.SurveyId == surveyId).OrderBy(x => x.Order).Skip(skip).Take(take).ToList();

            return Task.FromResult(models);
        }

        public Task<List<Question>> GetBySurveyId(int surveyId)
        {
            var models = DBSet.Where(x => x.SurveyId == surveyId).ToList();
            
            return Task.FromResult(models);
        }

        public Task<List<Question>> GetWithAnswerBySurveyId(int surveyId)
        {
            var models = DBSet.Include(m => m.Answers).Where(x => x.SurveyId == surveyId).ToList();

            return Task.FromResult(models);
        }

        public Task<List<Question>> GetParentBySurveyId(int surveyId)
        {
            var models = DBSet.Where(x => x.SurveyId == surveyId && (x.ParentQuestionId == null || x.ParentQuestionId == 0)).ToList();
            return Task.FromResult(models);
        }

        public Task<List<Question>> GetChildByParentQuestionId(int questionId)
        {
            var models = DBSet.Where(x => x.ParentQuestionId == questionId).ToList();
            return Task.FromResult(models);
        }

        public int GetNewOrder(int surveyId)
        {
            var lastQuestion = DBSet.Where(x => x.SurveyId == surveyId).OrderByDescending(x => x.Order).FirstOrDefault();
            
            if (lastQuestion == null)
            {
                return 1;
            }
            else
            {
                return lastQuestion.Order + 1;
            }
        }

        public Task<Question> GetWithAnswerById(int questionId)
        {
            var model = DBSet.Include(m => m.Answers).Where(x => x.Id == questionId).FirstOrDefault();

            return Task.FromResult(model);
        }
    }
}
