using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SV.Business.Implementation
{
    public class EmailRepository : Repository<SurveySharedWithCustomers>, iEmailRepository
    {

        public EmailRepository(SVDBContext context) : base(context)
        {
        }
        public void InsertEmails(List<SurveySharedWithCustomers> s)
        {
            try
            {
                DBSet.AddRange(s); 
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SurveySharedWithCustomers> GetFlaggedUserData(int surveyID)
        {
            return DBSet.Where(x => x.SurveyID == surveyID).ToList();
        }

        public void UpdateSubmitFlag(int ID, int surveyID)
        {
            try
            {
                var user = DBSet.Where(x => x.ID.Equals(ID) && x.SurveyID.Equals(surveyID)).FirstOrDefault();
                user.HasSubmitted = true;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
