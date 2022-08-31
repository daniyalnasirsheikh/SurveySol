using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Business.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        List<Answer> GetAll(int surveyResponseProfileId);
    }
}
