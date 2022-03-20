using Microsoft.AspNetCore.Mvc;
using WebStore.Models;


namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        

        public IActionResult Index()
        {
            return View(__Employee);
        }

        public IActionResult Details(int Id)
        {
            var employee = __Employee.FirstOrDefault(e => e.Id == Id);

            if(employee == null) return NotFound();

            return View(employee);
        }
    }
}
