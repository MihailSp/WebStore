using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Domain.Entities;
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

        public IActionResult Create()
        {
            return View("Edit", new EmployeesViewModel());
        }

        public IActionResult Edit(int? Id)
        {
            if (Id is not { } id) return View(new EmployeesViewModel());

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
            if (Model.LastName == "Иванов" && Model.Age < 21)
                ModelState.AddModelError("", "Иванов должен быть старше 21 года");

            if(!ModelState.IsValid)
                return View(Model);

            var employee = new Employee
            {
                Id = Model.Id,
                FirstName = Model.FirstName,
                LastName = Model.LastName,
                Patronymic= Model.Patronymic,
                Age = Model.Age,
            };  
            
            if(Model.Id== 0)
            {
                var id = _EmployeesData.Add(employee);
                return RedirectToAction("Index", new { id });
            }

            _EmployeesData.Edit(employee);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

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
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_EmployeesData.Delete(id)) return NotFound();

            return RedirectToAction("Index");
        }
    }
}
