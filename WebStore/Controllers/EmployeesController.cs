using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _Logger;
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData, ILogger<EmployeesController> Logger)
        {
            _Logger = Logger;
            _EmployeesData = EmployeesData;
        }

        public IActionResult Index()
        {
            var employees = _EmployeesData.GetAll();
            return View(employees);
        }

        public IActionResult Details(int Id)
        {
            var employee = _EmployeesData.GetById(Id);

            if(employee == null) return NotFound();

            return View(employee);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee == null) return NotFound();

            var model = new EmployeesViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                ShortName = employee.ShortName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeesViewModel Model)
        {
            var employee = new Employee
            {
                Id = Model.Id,
                FirstName = Model.FirstName,
                LastName = Model.LastName,
                Age = Model.Age,
            };  
            
            _EmployeesData.Edit(employee);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
