using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;

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
    }
}
