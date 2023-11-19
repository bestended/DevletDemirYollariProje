using System;
using System.Collections.Generic;

namespace DevletDemirYollariProje.Models
{
    public partial class Personeller
    {
        public Personeller()
        {
            Kurumlars = new HashSet<Kurumlar>();
        }

        public int PersonelId { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public int? Yas { get; set; }
        public string? Telefon { get; set; }
        public string? Adresi { get; set; }

        public virtual ICollection<Kurumlar> Kurumlars { get; set; }
    }
}
