using Microsoft.AspNetCore.Mvc;
using BagelsR.Models;

namespace BagelsR.Controllers
{
    public class BagelsController : Controller
    {
        public IActionResult Index()
        {
            var allBagels = Bagel.GetBagels();
            return View(allBagels);
        }
    }
}