using System;

namespace u1_depoMalzemeProjeIlkAsama
{
    public class Malzemeler
    {
        // alanlar (fields) :
        private int malzKod;
        private string kategori;
        private string ad;
        private int stokAdet; 

        // properties (özellikler):
        public int MalzKod { get { return malzKod; } set { malzKod = value; } }
        public string Kategori { get { return kategori; } set { kategori = value; } }
        public string Ad { get { return ad; } set { ad = value.ToUpper(); } }
        public int StokAdet { get { return stokAdet; } set { if (value < 0) { stokAdet = Math.Abs(value); } else if (value > 100) { stokAdet = 100; } else { stokAdet = value; } } }
        public Malzemeler() { } // constructor
        // public Malzemeler(int malzKod, string kategori, string ad, int stokAdet) { MalzKod = malzKod; Kategori = kategori; Ad = ad; StokAdet = stokAdet; }
 
    }
}
