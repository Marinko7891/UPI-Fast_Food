using System;
using System.Windows.Forms;

namespace UPI
{
    public partial class Medeni : Form
    {
        public Medeni()
        {
            InitializeComponent();
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

        //dodajemo sve u listbox i zbrajamo ukupnu cijenu
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
                    Pocetna1.instance.listre.Items.Add("MEDENI");
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
                    Pocetna1.instance.listre.Items.Add("MEDENI");

                    //Pocetna1.instance.listKolicina.Items.Add(txtKolicinaChickena.Text);
                    //radi ovo!!!
                    double c = double.Parse(cijena.Text);
                    Pocetna1.instance.zbroj += double.Parse(cijena.Text);
                    string haj = Pocetna1.instance.zbroj.ToString();
                    Pocetna1.instance.lblUkupn.Text = haj;





                }
            }
        }

        //dodajemo sve 
        private void btnPizzaMijM_Click(object sender, EventArgs e)
        {
            Dodaj(txtPizzaMijM, lblPizzaMijM, lblPizzaMijMC);
        }

        private void btnPizza4_Click(object sender, EventArgs e)
        {
            Dodaj(txtPizza4, lblPizza4, lblPizza4C);
        }

        private void btnPizzaMed_Click(object sender, EventArgs e)
        {
            Dodaj(txtPizzaMed, lblPizzaMed, lblPizzaMedC);
        }

        private void btnPizzaVeg_Click(object sender, EventArgs e)
        {
            Dodaj(txtPizzaVeg, lblPizzaVeg, lblPizzaVegC);
        }

        private void btnSirSun_Click(object sender, EventArgs e)
        {
            Dodaj(txtSirSun, lblSirSun, lblSirSunC);
        }

        private void btnTorTunj_Click(object sender, EventArgs e)
        {
            Dodaj(txtTorTunj, lblTorTunj, lblTorTunjC);
        }
    }
}
