using Microsoft.AspNetCore.Mvc;

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

        public IActionResult ContentString(String Id = "-Id-")
        {
            return Content($"content: {Id}");
        }

        public IActionResult ConfigStr()
        {
            return Content($"content: {_Configuration["ServerGreetings"]}");
        }
    }
}
