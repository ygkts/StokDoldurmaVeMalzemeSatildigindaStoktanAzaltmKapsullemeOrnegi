using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace u1_depoMalzemeProjeIlkAsama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public enum kategoriSecim { kırtasiye, sarf, elektronik}
        public enum elektronikMalz { klasikHesapMakinesi, bilimselHesapMakinesi, masaTelefonu, duvarSaati }
        public enum sarfMalz { kartus, toner, kagit, sertifikaKagidi }
        public enum kirtasiyeMalz { defter, kalem, tahtakalemi, silgi, atac, zımba }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboMalzKate.Items.AddRange(Enum.GetNames(typeof(kategoriSecim)));
            comboMalzKate.SelectedIndex = 0;

            comboCategori.Items.AddRange(Enum.GetNames(typeof(kategoriSecim)));
            comboCategori.SelectedIndex = 0;

        }

        public int sayac = 0;

        Malzemeler mal = new Malzemeler();
        Stok stk = new Stok();
        List<IPersoneller> perList = new List<IPersoneller>();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (comboMalzKate.Text=="kırtasiye")
            {
                KirtasiyeMalz krt = new KirtasiyeMalz(Convert.ToInt32(txtMalzKod.Text), comboMalzKate.Text, comboMazAd.Text, Convert.ToInt32(txtStokAdet.Text));
                stk.stokEkle(krt);

                ListViewItem kayit = new ListViewItem();
                kayit.Text = krt.MalzKod.ToString();
                kayit.SubItems.Add(krt.Kategori);
                kayit.SubItems.Add(krt.Ad);
                kayit.SubItems.Add(krt.StokAdet.ToString());
                listView1.Items.Add(kayit);

            }
            else if (comboMalzKate.Text == "sarf")
            {
                SarfMalz sarf = new SarfMalz(Convert.ToInt32(txtMalzKod.Text), comboMalzKate.Text, comboMazAd.Text, Convert.ToInt32(txtStokAdet.Text));
                stk.stokEkle(sarf);

                ListViewItem kayit = new ListViewItem();
                kayit.Text = sarf.MalzKod.ToString();
                kayit.SubItems.Add(sarf.Kategori);
                kayit.SubItems.Add(sarf.Ad);
                kayit.SubItems.Add(sarf.StokAdet.ToString());
                listView1.Items.Add(kayit);
            }
            else if (comboMalzKate.Text == "elektronik")
            {
                ElektronikMalz elek = new ElektronikMalz(Convert.ToInt32(txtMalzKod.Text), comboMalzKate.Text, comboMazAd.Text, Convert.ToInt32(txtStokAdet.Text));
                stk.stokEkle(elek);

                ListViewItem kayit = new ListViewItem();
                kayit.Text = elek.MalzKod.ToString();
                kayit.SubItems.Add(elek.Kategori);
                kayit.SubItems.Add(elek.Ad);
                kayit.SubItems.Add(elek.StokAdet.ToString());
                listView1.Items.Add(kayit);
            }
            sayac += Convert.ToInt16(stk.stokAdetBul());
            labelStokAdet.Text = sayac.ToString();
        }

        private void comboMalzKate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMalzKate.SelectedIndex == 0)
            {
                comboMazAd.Items.Clear();
                comboMazAd.Items.AddRange(Enum.GetNames(typeof(kirtasiyeMalz)));
                comboMazAd.SelectedIndex = 0;
            }
            else if (comboMalzKate.SelectedIndex == 1)
            {
                comboMazAd.Items.Clear();
                comboMazAd.Items.AddRange(Enum.GetNames(typeof(sarfMalz)));
                comboMazAd.SelectedIndex = 0;
            }
            else if (comboMalzKate.SelectedIndex == 2)
            {
                comboMazAd.Items.Clear();
                comboMazAd.Items.AddRange(Enum.GetNames(typeof(elektronikMalz)));
                comboMazAd.SelectedIndex = 0;
            }
        }

        private void btnEkle2_Click(object sender, EventArgs e)
        {
            if (comboMalzKate.Text == "kırtasiye")
            {
                KirtasiyeMalz krt = new KirtasiyeMalz(int.Parse(txtPerNo.Text), txtPerAd.Text, txtPerSOyad.Text, comboCategori.Text, comboMalAd.Text, int.Parse(txtIstenenAdet.Text));
                stk.stokCikar(krt);

                // datagridview'e ekleme
                krt.MalzKod = int.Parse(txtPerNo.Text);
                krt.PerAd = txtPerAd.Text;
                krt.PerSoyad = txtPerSOyad.Text;
                krt.MalzKategori = comboCategori.Text;
                krt.MalzAd = comboMalAd.Text;
                krt.IstenenAdet = int.Parse(txtIstenenAdet.Text);

                perList.Add(krt);
                DoldurPersonel(perList);

            }
            else if (comboMalzKate.Text == "sarf")
            {
                SarfMalz sarf = new SarfMalz(int.Parse(txtPerNo.Text), txtPerAd.Text, txtPerSOyad.Text, comboCategori.Text, comboMalAd.Text, int.Parse(txtIstenenAdet.Text));
                stk.stokCikar(sarf);

                // datagridview'e ekleme
                sarf.MalzKod = int.Parse(txtPerNo.Text);
                sarf.PerAd = txtPerAd.Text;
                sarf.PerSoyad = txtPerSOyad.Text;
                sarf.MalzKategori = comboCategori.Text;
                sarf.MalzAd = comboMalAd.Text;
                sarf.IstenenAdet = int.Parse(txtIstenenAdet.Text);

                perList.Add(sarf);
                DoldurPersonel(perList);
            }
            else if (comboMalzKate.Text == "elektronik")
            {
                ElektronikMalz elek = new ElektronikMalz(int.Parse(txtPerNo.Text), txtPerAd.Text, txtPerSOyad.Text, comboCategori.Text, comboMalAd.Text, int.Parse(txtIstenenAdet.Text));
                stk.stokCikar(elek);

                // datagridview'e ekleme
                elek.MalzKod = int.Parse(txtPerNo.Text);
                elek.PerAd = txtPerAd.Text;
                elek.PerSoyad = txtPerSOyad.Text;
                elek.MalzKategori = comboCategori.Text;
                elek.MalzAd = comboMalAd.Text;
                elek.IstenenAdet = int.Parse(txtIstenenAdet.Text);

                perList.Add(elek);
                DoldurPersonel(perList);
            }
            sayac -= Convert.ToInt16(stk.stokAdetBul());
            labelStokAdet.Text = sayac.ToString();
        }

        private void DoldurPersonel(List<IPersoneller> perList)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = perList;
        }

        private void comboCategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCategori.SelectedIndex == 0)
            {
                comboMalAd.Items.Clear();
                comboMalAd.Items.AddRange(Enum.GetNames(typeof(kirtasiyeMalz)));
                comboMalAd.SelectedIndex = 0;
            }
            else if (comboCategori.SelectedIndex == 1)
            {
                comboMalAd.Items.Clear();
                comboMalAd.Items.AddRange(Enum.GetNames(typeof(sarfMalz)));
                comboMalAd.SelectedIndex = 0;
            }
            else if (comboCategori.SelectedIndex == 2)
            {
                comboMalAd.Items.Clear();
                comboMalAd.Items.AddRange(Enum.GetNames(typeof(elektronikMalz)));
                comboMalAd.SelectedIndex = 0;
            }
        }
    }
}
