using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {       
        private readonly IConfiguration _Configuration;
        private readonly ILogger<EmployeesController> _Logger;
        private readonly IEmployeesData _EmployeesData;

        public HomeController(IConfiguration Configuration, IEmployeesData EmployeesData, ILogger<EmployeesController> Logger) 
        { 
            _Configuration = Configuration;
            _Logger = Logger;
            _EmployeesData = EmployeesData;
        }
        public IActionResult Index([FromServices] IProductData ProductData)
        {
            var products = ProductData.GetProducts()
                .OrderBy(x => x.Order)
                .Take(6)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl,
                });

            ViewBag.Products = products;

            return View();
        }

        public IActionResult ContentString(String Id)
        {
            var employees = _EmployeesData.GetAll();

            //ViewBag.Message = Id;
            return View(employees);
        }

        public IActionResult ConfigStr()
        {
            return Content($"content: {_Configuration["ServerGreetings"]}");
        }        
    }
}
