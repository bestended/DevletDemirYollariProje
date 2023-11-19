using DevletDemirYollariProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevletDemirYollariProje.Controllers
{
    public class MusterilerController : Controller
    {
        public readonly DevletDemirYollariContext db;
        public MusterilerController(DevletDemirYollariContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var sonuc = db.Musterilers.ToList();
            return View(sonuc);
        }

        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create(Musteriler Musteriler)
        {
            db.Musterilers.Add(Musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {

            var sonuc = db.Musterilers.FirstOrDefault(i => i.MusteriId == id);
            return View(sonuc);


        }

        [HttpPost]
        public IActionResult Edit(int id, Musteriler Musteriler)
        {
            db.Update(Musteriler);
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        public IActionResult Delete(int id)
        {
            var sonuc = db.Musterilers.FirstOrDefault(i => i.MusteriId == id);
            db.Musterilers.Remove(sonuc);
            db.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}
