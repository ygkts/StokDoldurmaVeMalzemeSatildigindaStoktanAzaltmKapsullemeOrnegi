namespace u1_depoMalzemeProjeIlkAsama
{
    class ElektronikMalz : Malzemeler, IPersoneller
    {
        public int PerKod { get; set; }
        public string PerAd { get; set; }
        public string PerSoyad { get; set; }
        public string MalzKategori { get; set; }
        public string MalzAd { get; set; }
        public int IstenenAdet { get; set; }
        // constructor :
        public ElektronikMalz(int malzKod, string kategori, string ad, int stokAdet )
        {
            MalzKod = malzKod;
            Kategori = kategori;
            Ad = ad;
            StokAdet = stokAdet;
        }
        public ElektronikMalz(int perKod, string perAd, string perSoyad, string malzKategori, string malzAd, int istenenAdet)
        {
            PerKod = perKod;
            PerAd = perAd;
            PerSoyad = perSoyad;
            MalzKategori = malzKategori;
            MalzAd = malzAd;
            IstenenAdet = istenenAdet;
        }
    }
}
