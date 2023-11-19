using DevletDemirYollariProje.Models;
using DevletDemirYollariProje.Models.OrtakTablolar;
using Microsoft.AspNetCore.Mvc;

namespace DevletDemirYollariProje.Controllers
{
    public class KurumPersonelController : Controller
    {
        public readonly DevletDemirYollariContext db;

        public KurumPersonelController(DevletDemirYollariContext db)
        {
            this.db = db;   
        }



        public IActionResult joinKurumPers()
        {

            var sonuc = (from k in db.Kurumlars
                         join p in db.Personellers
                         on k.PersonelId equals p.PersonelId
                         select new KurumPersonel
                         {
                             KurumId = k.KurumId,
                             KurumAdi = k.KurumAdi,
                             KurulusTarihi = k.KurulusTarihi,
                             KurumMerkezi = k.KurumMerkezi,
                             CalisanSayisi = k.CalisanSayisi,

                             Adi = p.Adi,
                             Soyadi = p.Soyadi,
                             Telefon = p.Telefon,
                             Yas = p.Yas


                         }

                       ).ToList();



            return View(sonuc);
        }
      

    }
}
