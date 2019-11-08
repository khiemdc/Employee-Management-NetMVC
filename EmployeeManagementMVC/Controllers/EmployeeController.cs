using EmployeeManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManagementEntities _context = new EmployeeManagementEntities();

        // GET All Employees
        public ActionResult Index()
        {
            List<Employee> employeeList = _context.Employees.ToList();

            EmployeeViewModel employeeVM = new EmployeeViewModel();

            List<EmployeeViewModel> employeeVMList = employeeList.Select(x => new EmployeeViewModel
            {
                EmployeeId = x.EmployeeId,
                Name = x.Name,
                DepartmentId = x.DepartmentId,
                Address = x.Address,
                DepartmentName = x.Department.DepartmentName
            }).ToList();

            return View(employeeVMList);
        }

        public ActionResult EmployeeDetail(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);

            EmployeeViewModel employeeVM = new EmployeeViewModel()
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Address = employee.Address,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department.DepartmentName
            };
            
            return View(employeeVM);
        }

        public ActionResult CreateEmployee()
        {

            return View("CreateEmployee");
        }

}
}