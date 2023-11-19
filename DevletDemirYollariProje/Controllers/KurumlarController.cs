using DevletDemirYollariProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace DevletDemirYollariProje.Controllers
{
    public class KurumlarController : Controller
    {
        public readonly DevletDemirYollariContext db;
        public KurumlarController(DevletDemirYollariContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            //var sonuc = db.Personellers.Include("KurumId").ToList();
            //return View(sonuc);

            var sonuc = db.Kurumlars.ToList();
            return View(sonuc);
        }

    
        public IActionResult Create()
        {
            ViewData["PersonelId"] = new SelectList(db.Personellers, "PersonelId", "PersonelId");
            ViewData["PeronId"] = new SelectList(db.Peronlars, "PeronId", "PeronId");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kurumlar Kurumlar)
        {
            db.Kurumlars.Add(Kurumlar);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {

            var sonuc = db.Kurumlars.FirstOrDefault(i => i.KurumId == id);
            return View(sonuc);


        }

        [HttpPost]
        public IActionResult Edit(int id, Kurumlar Kurumlar)
        {
            db.Update(Kurumlar);
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        public IActionResult Delete(int id)
        {
            var sonuc = db.Kurumlars.FirstOrDefault(i => i.KurumId == id);
            db.Kurumlars.Remove(sonuc);
            db.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}
