using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UPI
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfood_dostava;Integrated Security=True";
        public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfod;Integrated Security=True";

        //ovo sluzi za provjerit sve textboxeve
        public bool Registriraj(string a, string b, string c, string d, string e)
        {
            if (a != "" && b != "" && c != "" && d != "" && e != "")
            {
                //IME
                if (a.Length < 3)
                {
                    MessageBox.Show("Ime mora biti duze od 3 slova");
                    return false;
                }
                //SIFRA
                if (b.Length < 8)
                {
                    MessageBox.Show("Lozinka mora imati bar 8slova");
                    return false;
                }
                //EMAIL
                if (!c.Contains("@"))
                {
                    MessageBox.Show("Krivo unesen email");
                    return false;
                }

                try
                {
                    int.Parse(d);
                }
                catch
                {
                    MessageBox.Show("Morate unijeti brojeve za telefon: ");
                    return false;
                }

            }
            return true;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            //ako vec postoji korisnik s tim imenom vracamo se nazad
            SqlCommand cmd1 = new SqlCommand("select KORISNICKO_IME FROM KUPAC where KORISNICKO_IME=@KORISNICKO_IME", con);
            cmd1.Parameters.AddWithValue("KORISNICKO_IME", txtIme.Text);
            SqlDataReader reader1;
            reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                MessageBox.Show("Vec postoji korisnik sa upisanim korisničkim imenom");
                return;
            }

            reader1.Close();
            ///ako ovo radi saljemo u bazu novog kupca
            if (Registriraj(txtIme.Text, txtLoz.Text, txtEmail.Text, txtTel.Text, txtAdresa.Text))
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "insert into KUPAC(KORISNICKO_IME,LOZINKA,E_MAIL,ADRESA,TELEFON)values('" + txtIme.Text.ToString() + "','" + txtLoz.Text.ToString() + "','" + txtEmail.Text.ToString() + "','" + txtAdresa.Text.ToString() + "','" + txtTel.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registrirani ste!'\n'Možete se prijaviti!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Niste povezani sa serverom");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            txtLoz.PasswordChar = '\0';
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            txtLoz.PasswordChar = '*';
        }
    }
}
