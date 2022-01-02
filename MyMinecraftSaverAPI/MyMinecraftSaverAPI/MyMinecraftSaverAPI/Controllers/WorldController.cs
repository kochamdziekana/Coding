using Microsoft.AspNetCore.Mvc;

namespace MyMinecraftSaverAPI.Controllers
{
    public class WorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
