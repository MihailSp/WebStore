﻿using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {       
        private readonly IConfiguration _Configuration;

        public HomeController(IConfiguration Configuration) { _Configuration = Configuration; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentString(String Id)
        {
             List<Employee> __Employee = new()
             {
                 new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 23 },
                 new Employee { Id = 2, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 27 },
                 new Employee { Id = 3, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 18 }
             };

            ViewBag.Message = Id;
            return View(__Employee);
        }

        public IActionResult ConfigStr()
        {
            return Content($"content: {_Configuration["ServerGreetings"]}");
        }

        //public IActionResult Employees()
        //{
        //    return View(__Employee);
        //}
    }
}
