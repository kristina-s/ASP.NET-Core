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
    public class PizzaController : Controller
    {
        //dependency injection
        private IPizzaRepository pizzas;
        public PizzaController(IPizzaRepository repository)
        {
            pizzas = repository;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to our pizza ordering app!";

            var model = pizzas.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var pizza = pizzas.Get(id);
            return View(pizza);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePizzaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pizza = new Pizza();
                pizza.Name = model.Name;
                pizza.PizzaTypeId = model.PizzaTypeId;
                pizza.Size = model.Size;
                pizza.Price = model.Price;
                pizzas.Add(pizza);
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Pizza pizza = pizzas.Get(id);
            if (pizza == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel
                {
                    RequestId = id.ToString()
                };
                return View("Error", errorViewModel);
            }

            EditPizzaViewModel editPizzaViewModel = new EditPizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                PizzaTypeId = pizza.PizzaTypeId,
                Size = pizza.Size,
                Price = pizza.Price

            };
            return View(editPizzaViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditPizzaViewModel model)
        {
            Pizza pizza = pizzas.Get(model.Id);
            if (ModelState.IsValid)
            {
                pizza.Name = model.Name;
                pizza.PizzaTypeId = model.PizzaTypeId;
                pizza.Size = model.Size;
                pizza.Price = model.Price;
                pizzas.Update(pizza);
                return View("Details", pizza);

            }
            return View("Details", pizza);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Pizza pizza = pizzas.Get(id);
            if(pizza != null)
            {
                return View(pizza);
            }
            return View(pizza);
        }

       [HttpPost]
       public IActionResult Delete(Pizza pizza)
        {
            
            pizzas.Delete(pizza.Id);
            return RedirectToAction("Index");
        }
    }
}