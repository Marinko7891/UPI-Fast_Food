using System;
using System.Windows.Forms;

namespace UPI
{

    public partial class MCDonalds : Form
    {
        public static MCDonalds instance;
        //ovo je za Chichenbox
        public Label lblChikenBoxx;
        public Label lblChickenCijena;
        public TextBox txtKolicinaChickena;
        public double z = 0;
        ListBox g = Pocetna1.instance.listCijena;             
        public MCDonalds()
        {
            InitializeComponent();
            instance = this;
            lblChikenBoxx = LblChiBox;
            lblChickenCijena = LblChiBoxC;
            txtKolicinaChickena = txtchicken;
        }

        //provjerava jeli ispravno unesena kolicina
        public bool ProvjeriKolicinu(string a)
        {
            int b;
            if (a == "")
            {
                return true;
            }
            try
            {
                int.Parse(a);
                b = int.Parse(a);
            }
            catch
            {
                return false;
            }
            if (b == 0)
            {
                return false;
            }
            if (b < 0)
            {
                return false;
            }
            return true;
        }

        //metoda koja dodaje ovo sve u listbox i zbraja ukupnu narudzbu
        public void Dodaj(TextBox kolicina, Label proizvod, Label cijena)
        {
            if (!ProvjeriKolicinu(kolicina.Text))
            {
                MessageBox.Show("Neispravna kolicina");
            }
            else
            {
                if (kolicina.Text != "")
                {
                    double a = double.Parse(cijena.Text);
                    double b = double.Parse(kolicina.Text);
                    Pocetna1.instance.listKosarica.Items.Add(proizvod.Text);
                    Pocetna1.instance.listKolicina.Items.Add(kolicina.Text);
                    Pocetna1.instance.listCijena.Items.Add(a * b);
                    Pocetna1.instance.listre.Items.Add("McDonalds");
                    //oovo radii
                    double c = a * b;
                    Pocetna1.instance.zbroj += c;
                    string haj = Pocetna1.instance.zbroj.ToString();
                    Pocetna1.instance.lblUkupn.Text = haj;
                }
                else
                {
                    kolicina.Text = "1";
                    Pocetna1.instance.listKolicina.Items.Add(kolicina.Text);
                    Pocetna1.instance.listKosarica.Items.Add(proizvod.Text);
                    Pocetna1.instance.listCijena.Items.Add(cijena.Text);
                    Pocetna1.instance.listre.Items.Add("McDonalds");
                    double c = double.Parse(cijena.Text);
                    Pocetna1.instance.zbroj += double.Parse(cijena.Text);
                    string haj = Pocetna1.instance.zbroj.ToString();
                    Pocetna1.instance.lblUkupn.Text = haj;
                }
            }

        }
        //za dodavaje jela u kosaricu
        private void BtnChiBox_Click(object sender, EventArgs e)
        {
            Dodaj(txtchicken, lblChikenBoxx, lblChickenCijena);
        }
        private void btnChiMc_Click(object sender, EventArgs e)
        {
            Dodaj(txtChiMc, lblChiMcN, lblChiMcC);
        }
        private void btnBigTasC_Click(object sender, EventArgs e)
        {
            Dodaj(txtBigTas, lblBigTas, lblBigTasC);
        }
        private void btnMcWrap_Click(object sender, EventArgs e)
        {
            Dodaj(txtMcWrap, lblMcWrap, lblMcWrapC);
        }
        private void btnChiStr_Click(object sender, EventArgs e)
        {
            Dodaj(txtChiStr, lblChiStr, lblChiStrC);
        }
        private void btnMcToast_Click(object sender, EventArgs e)
        {
            Dodaj(txtMcToast, lblMcToast, lblMcToastC);
        }
    }
}
