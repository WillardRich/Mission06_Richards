using Microsoft.AspNetCore.Mvc;

namespace Mission06_Richards.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult AddMovie()
        {
            return View();
        }
    }
}
