using System;
using System.Collections.Generic;

namespace DevletDemirYollariProje.Models
{
    public partial class Kurumlar
    {
        public Kurumlar()
        {
            Trenlers = new HashSet<Trenler>();
        }

        public int KurumId { get; set; }
        public string? KurumAdi { get; set; }
        public DateTime? KurulusTarihi { get; set; }
        public string? KurumMerkezi { get; set; }
        public int? CalisanSayisi { get; set; }
        public int PersonelId { get; set; }
        public int PeronId { get; set; }

        public virtual Peronlar Peron { get; set; } = null!;
        public virtual Personeller Personel { get; set; } = null!;
        public virtual ICollection<Trenler> Trenlers { get; set; }
    }
}
