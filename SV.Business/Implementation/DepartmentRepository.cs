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
