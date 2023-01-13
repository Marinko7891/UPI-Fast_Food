using System;
using System.Windows.Forms;

namespace UPI
{
    public partial class Bili_Pivac : Form
    {
        public Bili_Pivac()
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
                    Pocetna1.instance.listre.Items.Add("BILI PIVAC");
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
                    Pocetna1.instance.listre.Items.Add("BILI PIVAC");

                    //Pocetna1.instance.listKolicina.Items.Add(txtKolicinaChickena.Text);
                    //radi ovo!!!
                    double c = double.Parse(cijena.Text);
                    Pocetna1.instance.zbroj += double.Parse(cijena.Text);
                    string haj = Pocetna1.instance.zbroj.ToString();
                    Pocetna1.instance.lblUkupn.Text = haj;





                }
            }
        }

        //dodajemo sve u listbox
        private void btnTorPil_Click(object sender, EventArgs e)
        {
            Dodaj(txtTorPil, lblTorPil, lblTorPilC);
        }

        private void btnSenPil_Click(object sender, EventArgs e)
        {
            Dodaj(txtSenPil, lblSenPil, lblSenPilC);
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            Dodaj(txtHam, lblHam, lblHamC);
        }

        private void btnCevap_Click(object sender, EventArgs e)
        {
            Dodaj(txtCevap, lblcevap, lblcevapC);
        }

        private void btnPohPunj_Click(object sender, EventArgs e)
        {
            Dodaj(txtPohPunj, lblPohPunj, lblPohPunjC);
        }

        private void btnFre_Click(object sender, EventArgs e)
        {
            Dodaj(txtSalPil, lblSalPil, lblSalPilC);
        }
    }
}
