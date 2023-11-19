namespace DevletDemirYollariProje.Models.OrtakTablolar
{
    public class KurumPersonel
    {
        public int KurumId { get; set; }
        public string? KurumAdi { get; set; }
        public DateTime? KurulusTarihi { get; set; }
        public string? KurumMerkezi { get; set; }
        public int? CalisanSayisi { get; set; }


        public int PersonelId { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public int? Yas { get; set; }
        public string? Telefon { get; set; }
        public string? Adresi { get; set; }


    }
}
