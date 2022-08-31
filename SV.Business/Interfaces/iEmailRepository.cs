using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Business.Interfaces
{
    public interface iEmailRepository : IRepository<SurveySharedWithCustomers>
    {
        void UpdateSubmitFlag(int ID, int SurveyID);
        void InsertEmails(List<SurveySharedWithCustomers> s);
        List<SurveySharedWithCustomers> GetFlaggedUserData(int ID);
    }
}
