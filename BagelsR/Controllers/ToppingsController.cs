using Microsoft.AspNetCore.Mvc;
using BagelsR.Models;

namespace BagelsR.Controllers
{
    public class ToppingsController : Controller
    {
        public IActionResult Index()
        {
            var allToppings = Topping.GetToppings();
            return View(allToppings);
        }
    }
}