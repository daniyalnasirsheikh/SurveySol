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
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(SVDBContext context) : base(context)
        {
        }

        public List<Answer> GetAll(int surveyResponseProfileId)
        {
            return DBSet.Where(x => x.SurveyResponseProfileId == surveyResponseProfileId).ToList();
        }
    }
}
