using PizzaApp.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.MockRepositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        List<Employee> employees;

        public MockEmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee{Id=1, FirstName="Jonh", LastName="Smith", City="LA", HireDate=new DateTime(2018,3,3), Title="administration"},
                new Employee{Id=2, FirstName="Tim", LastName="Jensen", City="Detroit", HireDate=new DateTime(2015,12,12), Title="chef"},
                new Employee{Id=3, FirstName="Emma", LastName="Taylor", City="Miami", HireDate=new DateTime(2009,6,6), Title="chef"},
                new Employee{Id=4, FirstName="Steven", LastName="Preston", City="Miami", HireDate=new DateTime(2012,3,2), Title="delivery"}
            };
        }

        //create
        public Employee Add(Employee employee)
        {
            int nextId = employees.Max(p => p.Id) + 1;
            employee.Id = nextId;
            employees.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = employees.FirstOrDefault(x => x.Id == id);
            employees.Remove(employee);
            return employee;
        }

        public Employee Get(int id)
        {
            Employee employee = employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = employees.FirstOrDefault(x => x.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.FirstName = employeeChanges.FirstName;
                employee.LastName = employeeChanges.LastName;
                employee.City = employeeChanges.City;
                employee.HireDate = employeeChanges.HireDate;
                employee.Title = employeeChanges.Title;
            }
            return employee;
        }
    }
}
