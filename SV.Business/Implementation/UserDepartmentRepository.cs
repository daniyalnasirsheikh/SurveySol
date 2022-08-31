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
    public class UserDepartmentRepository : Repository<UserDepartments>, iUserDepartmentRepository
    {
        public UserDepartmentRepository(SVDBContext context) : base(context)
        {

        }

        public void MapUserDepartment(string UserId, string DepartmentId)
        {
            try
            {
                UserDepartments ud = new UserDepartments();
                ud.UserID = UserId;
                ud.DepartmentID = DepartmentId;

                DBSet.Add(ud);
                context.SaveChanges();

            }
            catch (Exception)
            {

            }
        }

        public void UpdateUserDepartment(string UserId, string DepartmentId)
        {
            UserDepartments ud = new UserDepartments();
            try
            {
                ud = DBSet.Where(x => x.UserID == UserId).FirstOrDefault();
                ud.DepartmentID = DepartmentId;
                context.SaveChanges();

            }
            catch (Exception)
            {

            }

        }

        public List<string> GetUsersByDepartmentIDs(string departmentID)
        {
            List<string> userIDs = new List<string>();
            try
            { 
                userIDs = DBSet. Where(x => x.DepartmentID.Contains(departmentID)).Select(y => y.UserID).ToList();
                //userIDs.AddRange(DBSet.Where(x => x.DepartmentID.Contains("")).Select(y => y.UserID).ToList());
            }
            catch (Exception)
            {

            }
            return userIDs;
        }

        public string GetUserDepartmentIDs(string UserId)
        {
            string departmentIDs = string.Empty;
            try
            {
                departmentIDs = DBSet.Where(x => x.UserID == UserId).Select(y => y.DepartmentID).FirstOrDefault();
             
            }
            catch (Exception)
            {

            }
            return departmentIDs;
        }

        public void DeleteUserDepartments(string UserId)
        {
            try
            {
                UserDepartments ud = new UserDepartments();
                ud = DBSet.Where(x => x.UserID.Equals(UserId)).FirstOrDefault();
                DBSet.Remove(ud);
                context.SaveChanges();

            }
            catch (Exception)
            {

            }
        }
    }
}
