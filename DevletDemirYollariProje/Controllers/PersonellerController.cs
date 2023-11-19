using DevletDemirYollariProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevletDemirYollariProje.Controllers
{
    public class PersonellerController : Controller
    {
        public readonly DevletDemirYollariContext db;
        public PersonellerController(DevletDemirYollariContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var sonuc = db.Personellers.ToList();
            return View(sonuc);
        }

        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create(Personeller Personeller)
        {
            db.Personellers.Add(Personeller);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {

            var sonuc = db.Personellers.FirstOrDefault(i => i.PersonelId == id);
            return View(sonuc);


        }

        [HttpPost]
        public IActionResult Edit(int id, Personeller Personeller)
        {
            db.Update(Personeller);
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        public IActionResult Delete(int id)
        {
            var sonuc = db.Personellers.FirstOrDefault(i => i.PersonelId == id);
            db.Personellers.Remove(sonuc);
            db.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}
