using System;
using System.Windows.Forms;

namespace UPI
{
    public partial class Popaj : Form
    {
        public Popaj()
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

        //dodaje sve stvari u listbox i zbraja ukupnu cijenu
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
                    Pocetna1.instance.listre.Items.Add("POPAJ");
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
                    Pocetna1.instance.listre.Items.Add("POPAJ");

                    //Pocetna1.instance.listKolicina.Items.Add(txtKolicinaChickena.Text);
                    //radi ovo!!!
                    double c = double.Parse(cijena.Text);
                    Pocetna1.instance.zbroj += double.Parse(cijena.Text);
                    string haj = Pocetna1.instance.zbroj.ToString();
                    Pocetna1.instance.lblUkupn.Text = haj;





                }
            }
        }

        //dodavanje u listbox
        private void btnPizzaMij_Click(object sender, EventArgs e)
        {
            Dodaj(txtPizzaMij, lblPizzamij, lblPizzaMijC);
        }

        private void btnPizzaPlo_Click(object sender, EventArgs e)
        {
            Dodaj(txtPizzaPlo, lblPizzaPlo, lblPizzaPloC);
        }

        private void btnSenPec_Click(object sender, EventArgs e)
        {
            Dodaj(txtSenPec, lblSenPec, lblSenPecC);
        }

        private void btnSenPrs_Click(object sender, EventArgs e)
        {
            Dodaj(txtSenPrs, lblSenPrs, lblSenPrsC);
        }

        private void btnPovrce_Click(object sender, EventArgs e)
        {
            Dodaj(txtPovrce, lblPovrce, lblPovrceC);
        }

        private void btnMij_Click(object sender, EventArgs e)
        {
            Dodaj(txtMij, lblMije, lblMijeC);
        }
    }
}
