namespace u1_depoMalzemeProjeIlkAsama
{
    interface IPersoneller
    {
        int PerKod { get; set; }
        string PerAd { get; set; }
        string PerSoyad { get; set; }
        string MalzKategori { get; set; }
        string MalzAd { get; set; }
        int IstenenAdet { get; set; }
    }
}
