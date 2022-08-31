using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SV.Business.Implementation
{
    public class UsersLogRepository : Repository<UserLogs>, IUsersLogRepository
    {

        public UsersLogRepository(SVDBContext context) : base(context)
        {

        }
        
        public void AddNewUser(System.DateTime date, string userID, string userName)
        {
            try
            {
                UserLogs u = new UserLogs();
                u.UserID = userID;
                u.CreatedOn = Convert.ToDateTime(date);
                u.UserName = userName;
                DBSet.Add(u); 
                context.SaveChanges();
                
            }
            catch (Exception)
            {

            }
        }

        public void InsertLastLoggedInDate(System.DateTime date, string userName)
        {
            try
            {
                UserLogs u = new UserLogs();
                u = DBSet.Where(x => x.UserName.Equals(userName)).FirstOrDefault();
                u.LastLoggedIn = date;
                context.SaveChanges();

            }
            catch (Exception)
            {

            }
        }

        public void DeleteInactiveUsers(string userName)
        {
            try
            {
                UserLogs u = new UserLogs();
                u = DBSet.Where(x => x.UserName.Equals(userName)).FirstOrDefault();
                DBSet.Remove(u);
                context.SaveChanges();

            }
            catch (Exception)
            {

            }
        }

        public List<UserLogs> GetAllUserLogs()
        {
            try
            {
                //UserLogs admin = DBSet.Where(y =>y.UserName.Equals("Admin")).FirstOrDefault();
                List <UserLogs> logList = DBSet.Where(x => x.LastLoggedIn <= DateTime.Now.AddDays(-31) ||(x.CreatedOn <= DateTime.Now.AddDays(-31) && x.LastLoggedIn == null)).ToList();
                return logList;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
