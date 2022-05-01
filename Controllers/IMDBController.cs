using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    public class IMDBController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
