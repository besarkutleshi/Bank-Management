using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Persons;
using DataAccessLayer;
using EntityLayer.Persons;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Departaments;

namespace WebProjekti.Controllers
{
    [Authorize(Roles ="Admin,Super Admin")]
    public class EmployeeController : Controller
    {
        private static int EmpID = 0;
        private readonly EmployeeRepository _empRepository;
        private readonly DepartamentRepository _departamentRepository;
        public EmployeeController(EmployeeRepository empRepository,DepartamentRepository repository)
        {
            this._empRepository = empRepository;
            this._departamentRepository = repository;
        }

        [HttpGet]
        public IActionResult InsertEmployee()
        {
            ViewBag.Departaments = _departamentRepository.GetDepartaments();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(Employees emp)
        {
            if (ModelState.IsValid)
            {
                if (await _empRepository.InsertEmployee(emp) != null)
                {
                    return RedirectToAction("ListEmployees");
                }
            }
            ViewBag.ErrorTitle = "Registration not successful";
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (ModelState.IsValid)
            {
                if (await _empRepository.DeleteEmployee(id) != null)
                {
                    return RedirectToAction("ListEmployees");
                }
            }
            ViewBag.ErrorTitle = "Delete not successful";
            return View("Error");
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            ViewBag.Departaments = _departamentRepository.GetDepartaments();
            EmpID = id;
            var employee = await _empRepository.Read(id);
            if (employee != null)
            {
                return View(employee);
            }
            ViewBag.ErrorTitle = $"Employee with id : {id} not found ";
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employees emp)
        {
            if (ModelState.IsValid)
            {
                emp.PersonId = emp.Person.Id = EmpID;
                if (await _empRepository.UpdateEmployee(emp) != null)
                {
                    return RedirectToAction("ListEmployees");
                }
            }
            EmpID = 0;
            ViewBag.ErrorTitle = "Delete not successful";
            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> ListEmployees()
        {
            var emps = await _empRepository.Read();
            return View(emps);
        }

        [HttpGet]
        [Route("Employee/ListEmployees/{id:int}")]
        public async Task<IActionResult> ListEmployees(int id)
        {
            var emps = await _empRepository.Read(id);
            return View(emps);
        }


        [HttpGet]
        [Route("Employee/ListEmployees/{name}")]
        public async Task<IActionResult> ListEmployees(string name)
        {
            var emps = await _empRepository.Read(name);
            return View(emps);
        }
    }
}