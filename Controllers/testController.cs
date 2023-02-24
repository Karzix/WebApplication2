using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class testController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }
    }
}
