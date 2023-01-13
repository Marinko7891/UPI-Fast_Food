using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UPI
{
    public partial class MojProfil : Form
    {
        string name;
        public static MojProfil instance;
        public string d = "";
        public MojProfil()
        {
            InitializeComponent();
            instance = this;
        }

        public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfod;Integrated Security=True";

        //kada stisnemo botun prikazujemo elemente za mijenjanje lozinke
        private void button1_Click(object sender, EventArgs e)
        {
            lblnova.Show();
            lblnova1.Show();
            lblstara.Show();
            txtstara.Show();
            txtnova.Show();
            txtnova1.Show();
            btnpromini.Show();
        }

        //kada stisnemo ovaj botun prikazujemo sve kontakte restorana
        private void button3_Click(object sender, EventArgs e)
        {
            a1.Show();
            a2.Show();
            a3.Show();
            a4.Show();
            a5.Show();
            a6.Show();
            a7.Show();
            a8.Show();
            a9.Show();
            a10.Show();
            a11.Show();
            a12.Show();
        }

        List<Object> lista = new List<Object>();

        //kada stisnemo ovaj botun izbacuje nam sve narudzbe profila koji je ulogiran
        private void button2_Click(object sender, EventArgs e)
        {
            listanarudzbi.Show();
            BTNPROVJERI.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            //rtbnarudzbe.Show();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string ime = Pocetna1.instance.lblProfil.Text;
            if (con.State == System.Data.ConnectionState.Open)
            {
                //SqlCommand cmd = new SqlCommand("SELECT N.ID_NARUDZBA FROM NARUDZBA N INNER JOIN KUPAC K ON K.ID_KUPAC=N.ID_KUPAC WHERE K.KORISNICKO_IME=@KORISNICKO_IME", con);
                //SqlCommand cmd = new SqlCommand("SELECT N.ID_NARUDZBA,D.IME,D.PREZIME,N.DATUM,J.NAZIV_JELA,R.NAZIV,rj.kolicina,rj.CIJENA,n.CIJENA FROM DOSTAVLJAC D INNER JOIN NARUDZBA N ON D.ID_DOSTAVLJAC = N.ID_DOSTAVLJAC INNER JOIN RESTORAN_JELA RJ ON N.ID_NARUDZBA = RJ.ID_NARUDZBA INNER JOIN RESTORAN R ON R.ID_RESTORAN = RJ.ID_RESTORAN INNER JOIN JELA J ON J.ID_JELA = RJ.ID_JELA INNER JOIN KUPAC K ON K.ID_KUPAC = N.ID_KUPAC WHERE K.KORISNICKO_IME =@KORISNICKO_IME",con);
                SqlCommand cmd = new SqlCommand("SELECT N.ID_NARUDZBA,D.IME,D.PREZIME,N.CIJENA,N.DATUM FROM NARUDZBA N INNER JOIN DOSTAVLJAC D ON D.ID_DOSTAVLJAC=N.ID_DOSTAVLJAC INNER JOIN KUPAC K ON K.ID_KUPAC=N.ID_KUPAC WHERE K.KORISNICKO_IME=@KORISNICKO_IME", con);
                cmd.Parameters.AddWithValue("@KORISNICKO_IME", ime);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listanarudzbi.Items.Add(reader.GetInt32(0).ToString() + '\t' + reader.GetString(1) + "\t" + reader.GetString(2) + "\t" + reader.GetString(3) + "\t" + reader.GetString(4));
                }

            }

            else
            {
                MessageBox.Show("Nije spojeno");
            }

        }

        //provjeri jesu obe lozinke isto unesene
        public bool ProvjeriIspravnostLoz(string a, string b)
        {
            if (a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //provjerava jeli stara lozinka ispravno unesena
        public bool ProvjeriStaruLoz(string a, string b)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            SqlCommand cmd = new SqlCommand("select LOZINKA FROM KUPAC where KORISNICKO_IME=@KORISNICKO_IME", con);
            cmd.Parameters.AddWithValue("KORISNICKO_IME", a);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string c = reader.GetString(0);
                if (c == b)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //return true;
            }
            else
            {
                return false;
            }
        }

        //ako je ispravno unesena stara lozinka i dvi nove iste lozinka se mijenja
        private void btnpromini_Click(object sender, EventArgs e)
        {
            string stara = txtstara.Text;
            string nova = txtnova.Text;
            string nova1 = txtnova1.Text;
            string ime = Pocetna1.instance.lblProfil.Text;
            if (ProvjeriStaruLoz(ime, stara))
            {
                if (ProvjeriIspravnostLoz(nova, nova1))
                {
                    if (nova.Length < 7)
                    {
                        MessageBox.Show("Prekratka nova lozinka");
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(conString);
                        con.Open();

                        //string query = "UPDATE KUPAC SET LOZINKA='" + nova + "'WHERE KORISNICKO_IME=" + ime;                              
                        //SqlCommand cmd = new SqlCommand(query, con);
                        //cmd.ExecuteNonQuery();
                        string q = "UPDATE KUPAC SET LOZINKA=@LOZINKA WHERE KORISNICKO_IME=@KORISNICKO_IME";
                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@LOZINKA", nova);
                        cmd.Parameters.AddWithValue("@KORISNICKO_IME", ime);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Lozinka uspješno promijenjena");
                    }

                }
                else
                {
                    MessageBox.Show("Lozinke se ne podudaraju");
                }
            }
            else
            {
                MessageBox.Show("Krivo upisana stara lozinka");
            }


        }

        //sluzi za detaljnije pregledavanje narudzbe
        private void BTNPROVJERI_Click(object sender, EventArgs e)
        {
            int i = listanarudzbi.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("Odaberite narudzbu koju zelite pregledati");
                return;
            }
            string a = listanarudzbi.Items[i].ToString();
            d = a[0].ToString() + a[1].ToString() + a[2].ToString();


            MessageBox.Show(d);
            Narudzbe frm = new Narudzbe();
            frm.Show();

        }


    }
}
