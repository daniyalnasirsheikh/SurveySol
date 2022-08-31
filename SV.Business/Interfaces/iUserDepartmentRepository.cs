using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Business.Interfaces
{
    public interface iUserDepartmentRepository : IRepository<UserDepartments>
    {
        public void MapUserDepartment(string UserId, string DepartmentId);

        public void UpdateUserDepartment(string UserId, string DepartmentId);

        public string GetUserDepartmentIDs(string UserId);

        public List<string> GetUsersByDepartmentIDs(string departmentID);

        public void DeleteUserDepartments(string UserId);
        
    }
}
