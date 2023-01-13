using System;
using System.Windows.Forms;

namespace UPI
{
    public partial class Burger_King : Form
    {
        public Burger_King()
        {
            InitializeComponent();
        }
        //provjerava jeli ispravno unesena koicina
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

        //dodaje sve u listbox i zbraja ukupnu cijenu
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
                    Pocetna1.instance.listre.Items.Add("BURGER KING");
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
                    Pocetna1.instance.listre.Items.Add("BURGER KING");

                    //Pocetna1.instance.listKolicina.Items.Add(txtKolicinaChickena.Text);
                    //radi ovo!!!
                    double c = double.Parse(cijena.Text);
                    Pocetna1.instance.zbroj += double.Parse(cijena.Text);
                    string haj = Pocetna1.instance.zbroj.ToString();
                    Pocetna1.instance.lblUkupn.Text = haj;





                }
            }
        }

        //dodavamo u kosaricu
        private void btnMonBur_Click(object sender, EventArgs e)
        {
            Dodaj(txtMonBur, lblMonBur, lblMonBurC);
        }

        private void btnWinBur_Click(object sender, EventArgs e)
        {
            Dodaj(txtWinBur, lblWinBur, lblWinBurC);
        }

        private void btnVegSli_Click(object sender, EventArgs e)
        {
            Dodaj(txtVegSli, lblVegSli, lblVegSliC);
        }

        private void btnAvoVeg_Click(object sender, EventArgs e)
        {
            Dodaj(txtAvoVeg, lblAvoVeg, lblAvoVegC);
        }

        private void btnSmoke_Click(object sender, EventArgs e)
        {
            Dodaj(txtSmoke, lblSmoke, lblSmokeC);
        }

        private void btnFre_Click(object sender, EventArgs e)
        {
            Dodaj(txtFre, lblFre, lblFreC);
        }
    }
}
