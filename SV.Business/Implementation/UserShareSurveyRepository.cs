using Microsoft.EntityFrameworkCore;
using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Business.Implementation
{
    public class UserShareSurveyRepository : Repository<UserShareSurvey>, IUserShareSurveyRepository
    {
        public UserShareSurveyRepository(SVDBContext context) : base(context)
        {

        }

        public Task<List<UserShareSurvey>> GetBySurveyId(int surveyId)
        {
            var output = DBSet.Where(x => x.SurveyId == surveyId).ToListAsync();

            return output;
        }

        public async Task<bool> Save(List<UserShareSurvey> userShareSurveys)
        {
            try
            {
                if (userShareSurveys.Count > 0)
                {
                    var oldUserShareSurveys = await GetBySurveyId(userShareSurveys.FirstOrDefault().SurveyId);
                    DBSet.RemoveRange(oldUserShareSurveys);
                    await DBSet.AddRangeAsync(userShareSurveys);
                    await context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
