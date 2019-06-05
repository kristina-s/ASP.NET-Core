using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("employeepage")]
    public class EmployeeController : Controller
    {
        List<Employee> employees;

        public EmployeeController()
        {
            employees = new List<Employee>()
            {
                new Employee{Id=1, FirstName="Jonh", LastName="Smith", City="LA", HireDate=new DateTime(2018,3,3), Title="administration"},
                new Employee{Id=2, FirstName="Tim", LastName="Jensen", City="Detroit", HireDate=new DateTime(2015,12,12), Title="chef"},
                new Employee{Id=3, FirstName="Emma", LastName="Taylor", City="Miami", HireDate=new DateTime(2009,6,6), Title="chef"},
                new Employee{Id=4, FirstName="Steven", LastName="Preston", City="Miami", HireDate=new DateTime(2012,3,2), Title="delivery"}
            };
        }

        [Route("emp")]
        public IActionResult Index()
        {
            ViewData["Message"] = "This is a list of our employees.";
            var model = employees;
            return View(model);
        }

        [Route("Details")]
        public IActionResult Details(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);
            return View(employee);
        }

        [Route("Create")]
        public IActionResult Create(int id)
        {
            return View();
        }

        [Route("Delete")]
        public IActionResult Delete(int id)
        {         
            var list = employees.Where(x => x.Id != id).ToList();
            employees = list;                                 
            return View("Index", employees);
        }

        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}