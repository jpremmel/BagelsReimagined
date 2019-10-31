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

        public ActionResult Details(int id)
        {
            var bagel = Bagel.GetBagel(id);
            return View(bagel);
        }

        public ActionResult Edit(int id)
        {
            var bagel = Bagel.GetBagel(id);
            return View(bagel);
        }

        [HttpPost]
        public ActionResult Edit(Bagel bagel)
        {
            Bagel.EditBagel(bagel);
            return RedirectToAction("Details", new { id = bagel.BagelId });
        }
    }
}