using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace SV.Business.Implementation
{
    public class SurveyResponseProfileRepository : Repository<SurveyResponseProfile>, ISurveyResponseProfileRepository
    {
        public SurveyResponseProfileRepository(SVDBContext context) : base(context)
        {

        }
       
        public Task<List<SurveyResponseProfile>> GetBySurveyId(int surveyId)
        {
            var models = DBSet.Where(x => x.SurveyId == surveyId).ToList();
            return Task.FromResult(models);
        }

        public Task<List<SurveyResponseProfile>> GetLatestFiveResponsesByUserId(string userId)
        {
            var param = new SqlParameter("@UserId", userId);
            var models = DBSet.FromSqlRaw("GetTopFiveResponsesByUserId @UserId", param).ToList();
            return Task.FromResult(models);
        }

        public int TotalResponses(int surveyId)
        {
            return DBSet.Where(x => x.SurveyId == surveyId).Count();
        }

        public void DeleteResponsesBySurveyId(int surveyId)
        {
            var param = new SqlParameter("@SurveyId", surveyId);
            var rowsAffected = context.Database.ExecuteSqlRaw("DeleteResponsesBySurveyId @SurveyId", param);
        }


    }
}
