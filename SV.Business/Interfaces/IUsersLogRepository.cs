using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Business.Interfaces
{
    public interface IUsersLogRepository : IRepository<UserLogs>
    {
        void AddNewUser(System.DateTime date, string userID, string userName);

        void InsertLastLoggedInDate(System.DateTime date, string userName);

        public void DeleteInactiveUsers(string userName);
        public List<UserLogs> GetAllUserLogs();
    }
}
