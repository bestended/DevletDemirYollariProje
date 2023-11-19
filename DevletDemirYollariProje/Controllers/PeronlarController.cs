using DevletDemirYollariProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevletDemirYollariProje.Controllers
{
    public class PeronlarController : Controller
    {
        public readonly DevletDemirYollariContext db;
        public PeronlarController(DevletDemirYollariContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var sonuc=db.Peronlars.ToList();
            return View(sonuc);
        }

        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create(Peronlar peronlar)
        {
            db.Peronlars.Add(peronlar);
            db.SaveChanges();
            return RedirectToAction("Index");
                

        }

        public IActionResult Edit(int id)
        {

            var sonuc = db.Peronlars.FirstOrDefault(i => i.PeronId == id);
            return View(sonuc);


        }

        [HttpPost]
        public IActionResult Edit(int id,Peronlar peronlar)
        {
            db.Update(peronlar);
            db.SaveChanges();
          
            return RedirectToAction("Index");


        }
        public IActionResult Delete(int id)
        {
            var sonuc = db.Peronlars.FirstOrDefault(i=>i.PeronId==id);
            db.Peronlars.Remove(sonuc);
            db.SaveChanges();

            return RedirectToAction("Index");


        }



    }
}
