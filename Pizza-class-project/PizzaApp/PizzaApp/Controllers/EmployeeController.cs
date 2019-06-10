using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;
using PizzaApp.Models.IRepositories;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Controllers
{
    //[Route("employeepage")]
    public class EmployeeController : Controller
    {
        //dependency injection
        private IEmployeeRepository employees;
        public EmployeeController(IEmployeeRepository repository)
        {
            employees = repository;
        }

        //[Route("emp")]
        public IActionResult Index()
        {
            ViewData["Message"] = "This is a list of our employees.";
            var model = employees.GetAll();
            return View(model);
        }

        //[Route("Details")]
        public IActionResult Details(int id)
        {
            Employee employee = employees.Get(id);
            return View(employee);
        }

        //[Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.City = model.City;
                employee.HireDate = model.HireDate;
                employee.Title = model.Title;
                employees.Add(employee);
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        //[Route("Delete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = employees.Get(id);
            if (employee != null)
            {
                return View(employee);
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {

            employees.Delete(employee.Id);
            return RedirectToAction("Index");
        }


        //[Route("Edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = employees.Get(id);
            if (employee == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel
                {
                    RequestId = id.ToString()
                };
                return View("Error", errorViewModel);
            }

            EditEmployeeViewModel editEmployeeViewModel = new EditEmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                Title = employee.Title,
                City = employee.City,
            };
            return View(editEmployeeViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            Employee employee = employees.Get(model.Id);
            if (ModelState.IsValid)
            {
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.City = model.City;
                employee.HireDate = model.HireDate;
                employee.Title = model.Title;

                employees.Update(employee);
                return View("Details", employee);

            }
            return View("Details", employee);
        }
    }
}