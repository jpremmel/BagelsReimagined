using Microsoft.AspNetCore.Mvc;
using BagelsR.Models;
using System.Threading.Tasks;

namespace BagelsR.Controllers
{
    public class ToppingsController : Controller
    {
        public IActionResult Index()
        {
            var allToppings = Topping.GetToppings();
            return View(allToppings);
        }

        public ActionResult Edit(int id)
        {
            var topping = Topping.GetTopping(id);
            return View(topping);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Topping topping)
        {
            await Topping.EditTopping(topping);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Topping topping)
        {
            await Topping.CreateTopping(topping);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var topping = Topping.GetTopping(id);
            await Topping.DeleteTopping(topping);
            return RedirectToAction("Index");
        }
    }
}