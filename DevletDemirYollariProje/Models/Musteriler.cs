using System;
using System.Collections.Generic;

namespace DevletDemirYollariProje.Models
{
    public partial class Musteriler
    {
        public int MusteriId { get; set; }
        public string? TcKimlikNo { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Cinsiyet { get; set; }
        public string? Telefon { get; set; }
        public string? Mail { get; set; }
        public int TrenId { get; set; }

        public virtual Trenler Tren { get; set; } = null!;
    }
}
