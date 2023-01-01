using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Business.Interfaces
{
    public interface iDepartmentRepository : IRepository<Departments>
    {
        public List<Departments> GetAllDepartments();
        public Departments GetDepartmentByDepartmentID(int DepartmentID);
        public void CreateDepartment(Departments model);
        public void UpdateDepartment(Departments model);
        public void DeleteDepartment(int departmentId);
    }
}
