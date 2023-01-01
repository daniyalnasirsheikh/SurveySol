using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SV.Business.Interfaces;
using SV.Models.Entities;
using SV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SV.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly iDepartmentRepository _departmentRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityUser> roleManager;
        public DepartmentController(iDepartmentRepository departmentRepository, UserManager<IdentityUser> userManager)
        {
            this._departmentRepository = departmentRepository;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            return View(new DepartmentViewModel());
        }

        [HttpPost]
        public IActionResult Create(Departments model)
        {
            try
            {
                _departmentRepository.CreateDepartment(model);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction(nameof(Read));
        }

        public IActionResult Read()
        {
            List<Departments> departments = new List<Departments>();
            try
            {
                departments = _departmentRepository.GetAllDepartments();
            }
            catch (Exception ex)
            {

            }
            return View(departments);
        }

        public IActionResult Update(int id)
        {
            DepartmentViewModel model = null;
            try
            {
                var department = _departmentRepository.GetDepartmentByDepartmentID(id);
                model = new DepartmentViewModel { ID = department.ID, Department = department.Department };
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Departments model)
        {
            try
            {
                _departmentRepository.UpdateDepartment(model);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction(nameof(Read));
        }

        public IActionResult Delete(int id)
        {
            DepartmentViewModel model = null;
            try
            {
                var department = _departmentRepository.GetDepartmentByDepartmentID(id);
                model = new DepartmentViewModel {ID = department.ID, Department = department.Department };
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(DepartmentViewModel model)
        {
            try
            {
                _departmentRepository.DeleteDepartment(model.ID);
            }
            catch (Exception ex)
            {
            }
            
            return RedirectToAction(nameof(Read));
        }
    }
}
