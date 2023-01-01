using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SV.Business.Implementation
{
    public class DepartmentRepository : Repository<Departments>, iDepartmentRepository
    {

        public DepartmentRepository(SVDBContext context) : base(context)
        {

        }

        public void CreateDepartment(Departments model)
        {
            try
            {
                Departments obj = new Departments();
                obj.Department = model.Department;
                DBSet.Add(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }

        }

        public void UpdateDepartment(Departments model)
        {
            try
            {
                Departments obj = new Departments();
                obj = DBSet.Where(x => x.ID == model.ID).FirstOrDefault();
                obj.Department = model.Department;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }

        }

        public void DeleteDepartment(int departmentId)
        {
            try
            {
                Departments obj = new Departments();
                obj = DBSet.Where(x => x.ID.Equals(departmentId)).FirstOrDefault();
                DBSet.Remove(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }

        }

        public List<Departments> GetAllDepartments()
        {
            List<Departments> result = new List<Departments>();
            result = DBSet.ToList();
            return result;
        }


        public Departments GetDepartmentByDepartmentID(int DepartmentID)
        {
            return DBSet.Where(x => x.ID == DepartmentID).FirstOrDefault();
        }

    }
}
