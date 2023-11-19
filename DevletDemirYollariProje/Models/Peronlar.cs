using System;
using System.Collections.Generic;

namespace DevletDemirYollariProje.Models
{
    public partial class Peronlar
    {
        public Peronlar()
        {
            Kurumlars = new HashSet<Kurumlar>();
        }

        public int PeronId { get; set; }
        public int? PeronNumarasi { get; set; }
        public int? PeronSayisi { get; set; }
        public string? PeronMevki { get; set; }
        public int? PeronUzunluk { get; set; }
        public int? DurakSayisi { get; set; }

        public virtual ICollection<Kurumlar> Kurumlars { get; set; }
    }
}
