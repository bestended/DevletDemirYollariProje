using System;
using System.Collections.Generic;

namespace DevletDemirYollariProje.Models
{
    public partial class Trenler
    {
        public Trenler()
        {
            Musterilers = new HashSet<Musteriler>();
        }

        public int TrenId { get; set; }
        public string? TrenTipi { get; set; }
        public DateTime? KalkisTarihSaat { get; set; }
        public DateTime? VarisTarihSaat { get; set; }
        public int? VagonSayisi { get; set; }
        public string? KalkisYön { get; set; }
        public string? VarisYön { get; set; }
        public int KurumId { get; set; }

        public virtual Kurumlar Kurum { get; set; } = null!;
        public virtual ICollection<Musteriler> Musterilers { get; set; }
    }
}
