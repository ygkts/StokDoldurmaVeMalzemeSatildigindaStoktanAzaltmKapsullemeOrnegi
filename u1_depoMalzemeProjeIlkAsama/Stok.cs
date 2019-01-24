using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace u1_depoMalzemeProjeIlkAsama
{
    class Stok
    {
        private List<Malzemeler> liste = new List<Malzemeler>();
        public int stokAdetBul()
        {
            int toplam = 0;
            foreach (Malzemeler item in liste)
            {
                toplam += item.StokAdet;
            }
            return toplam;
        }
        public void stokEkle(Malzemeler malz)
        {
            liste.Add(malz);
        }
        public void stokCikar(Malzemeler malz)
        {
            if (liste.Count != 0)
            {
                liste.Remove(malz);
            }
            else
            {
                MessageBox.Show("Stokta YOK");
            }
            
        }
    }
}
