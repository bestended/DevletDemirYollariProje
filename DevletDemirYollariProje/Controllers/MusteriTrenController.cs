using DevletDemirYollariProje.Models;
using DevletDemirYollariProje.Models.OrtakTablolar;
using Microsoft.AspNetCore.Mvc;

namespace DevletDemirYollariProje.Controllers
{
    public class MusteriTrenController : Controller
    {

        public readonly DevletDemirYollariContext db;

        public MusteriTrenController(DevletDemirYollariContext db)
        {
            this.db = db;

        }

        public IActionResult MusTren()
        {

            //Merge 


            MusteriTren musteriTren = new MusteriTren();

            musteriTren.Musteri = db.Musterilers.ToList();
            musteriTren.Tren = db.Trenlers.ToList();

            return View(musteriTren);
        }
    }
}
