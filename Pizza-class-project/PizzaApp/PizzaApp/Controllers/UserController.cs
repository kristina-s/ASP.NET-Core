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
    public class UserController : Controller
    {
        //dependency injection
        private IUserRepository users;
        public UserController(IUserRepository repository)
        {
            users = repository;
        }
        //index
        public IActionResult Index()
        {
            var model = users.GetAll();
            return View(model);
        }
        //details
        public IActionResult Details(int id)
        {
            var user = users.Get(id);
            return View(user);
        }
        //create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.Name = model.Name;
                user.City = model.City;
                user.Address = model.Address;
                user.Email = model.Email;
                user.Phone = model.Phone;
                users.Add(user);
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        //edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = users.Get(id);
            if (user == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel
                {
                    RequestId = id.ToString()
                };
                return View("Error", errorViewModel);
            }

            EditUserViewModel editUserViewModel = new EditUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                City = user.City,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone
            };
            return View(editUserViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditUserViewModel model)
        {
            User user = users.Get(model.Id);
            if (ModelState.IsValid)
            {
                user.Name = model.Name;
                user.City = model.City;
                user.Address = model.Address;
                user.Email = model.Email;
                user.Phone = model.Phone;
                
                users.Update(user);
                return View("Details", user);

            }
            return View("Details", user);
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            User user = users.Get(id);
            if (user != null)
            {
                return View(user);
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {

            users.Delete(user.Id);
            return RedirectToAction("Index");
        }
    }
}