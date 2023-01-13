using System;
using System.Windows.Forms;

namespace UPI
{
    public partial class KFC : Form
    {
        public static KFC instance;
        public KFC()
        {
            InitializeComponent();
        }
        public double zbroj = Pocetna1.instance.zbroj;
        //provjerava jeli kolicina isrpavno unesena
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

        //za dodavanje svega u listbox i zbrajanje ukupne cijene
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
                    Pocetna1.instance.listre.Items.Add("KFC");
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
                    Pocetna1.instance.listre.Items.Add("KFC");

                    //Pocetna1.instance.listKolicina.Items.Add(txtKolicinaChickena.Text);
                    //radi ovo!!!
                    double c = double.Parse(cijena.Text);
                    Pocetna1.instance.zbroj += double.Parse(cijena.Text);
                    string haj = Pocetna1.instance.zbroj.ToString();
                    Pocetna1.instance.lblUkupn.Text = haj;





                }
            }
        }
        private void BtnChiBox_Click(object sender, EventArgs e)
        {
            Dodaj(txtKen, LblKen, LblKenC);
        }

        private void btnClaKos_Click(object sender, EventArgs e)
        {
            Dodaj(txtClaKos, lblClaKos, lblClaKosC);
        }

        private void btnGraBur_Click(object sender, EventArgs e)
        {
            Dodaj(txtGraBur, lblGraBur, lblGraBurC);
        }

        private void btnQurBox_Click(object sender, EventArgs e)
        {
            Dodaj(txtQurBox, lblQurBox, lblQurBoxC);
        }

        private void btnCheBox_Click(object sender, EventArgs e)
        {
            Dodaj(txtCheBox, lblCheBox, lblCheBoxC);
        }

        private void btnStriDel_Click(object sender, EventArgs e)
        {
            Dodaj(txtStriDel, lblStriDel, lblStriDelC);
        }
    }
}
