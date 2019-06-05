using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("pizzaapp")]
    public class PizzaController : Controller
    {
        List<Pizza> pizzas;
        public PizzaController()
        {
            pizzas = new List<Pizza>()
            {
                new Pizza {Id=1, Name="Capriciosa", PizzaTypeId=1, Size=Size.small, Price=150},
                new Pizza {Id=2, Name="Quatro Staggione", PizzaTypeId=2, Size=Size.medium, Price=250},
                new Pizza {Id=3, Name="Vegetariana", PizzaTypeId=3, Size=Size.large, Price=450}
            };
        }

        [Route("mypage")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to our pizza ordering app!";

            var model = pizzas;
            return View(model);
        }

        [Route("Details")]
        public IActionResult Details(int id)
        {
            var pizza = pizzas.FirstOrDefault(x => x.Id == id);
            return View(pizza);
        }

        [Route("Create")]
        public IActionResult Create(int id)
        {
            return View();
        }
    }
}