using DevletDemirYollariProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DevletDemirYollariProje.Controllers
{
    public class TrenlerController : Controller
    {
        public readonly DevletDemirYollariContext db;
        public TrenlerController(DevletDemirYollariContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {

            var sonuc = db.Trenlers.ToList();
            return View(sonuc);
        }

        public IActionResult Liste()
        {
            var sonuc = db.Trenlers.Include("Kurum");
            return View(sonuc);


        }


        public IActionResult Create()
        {
            ViewData["KurumId"] = new SelectList(db.Kurumlars, "KurumId", "KurumId");
            return View();


        }





        [HttpPost]
        public IActionResult Create(Trenler Trenler)
        {
            db.Trenlers.Add(Trenler);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {

            var sonuc = db.Trenlers.FirstOrDefault(i => i.TrenId == id);
            return View(sonuc);


        }

        [HttpPost]
        public IActionResult Edit(int id, Trenler Trenler)
        {
            db.Update(Trenler);
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        public IActionResult Delete(int id)
        {
            var sonuc = db.Trenlers.FirstOrDefault(i => i.TrenId == id);
            db.Trenlers.Remove(sonuc);
            db.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}
