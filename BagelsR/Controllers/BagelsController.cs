using Microsoft.AspNetCore.Mvc;
using BagelsR.Models;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Edit(Bagel bagel)
        {
            await Bagel.EditBagel(bagel);
            return RedirectToAction("Details", new { id = bagel.BagelId });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bagel bagel)
        {
            await Bagel.CreateBagel(bagel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        { 
            var bagel = Bagel.GetBagel(id);
            await Bagel.DeleteBagel(bagel);
            return RedirectToAction("Index");
        }
    }
}