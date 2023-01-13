using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UPI
{
    public partial class Admin : Form
    {
        public string d = "";
        public static Admin instance;

        public Admin()
        {
            InitializeComponent();
            instance = this;

        }
        public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfod;Integrated Security=True";
        //lista svih kupaca
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID_KUPAC,KORISNICKO_IME,E_MAIL,TELEFON FROM KUPAC", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listakupaca.Items.Add(reader.GetInt32(0) + "\t" + reader.GetString(1) + "\t" + reader.GetString(3) + "\t" + reader.GetString(2));
            }

            reader.Close();
            con.Close();
        }

        //listsa narudzbi
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT N.ID_NARUDZBA,D.IME,D.PREZIME,N.CIJENA,N.DATUM FROM NARUDZBA N INNER JOIN DOSTAVLJAC D ON D.ID_DOSTAVLJAC=N.ID_DOSTAVLJAC INNER JOIN KUPAC K ON K.ID_KUPAC=N.ID_KUPAC", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                adminovalista.Items.Add(reader.GetInt32(0) + "\t" + reader.GetString(1) + "\t" + reader.GetString(2) + "\t" + reader.GetString(3) + "\t" + reader.GetString(4));
            }




        }
        ///klikom na botun ako smo odabrali nesto mozemo pogledati detaljnije narudzbu
        private void button4_Click(object sender, EventArgs e)
        {
            int i = adminovalista.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("Odaberite narudzbu koju zelite pregledati");
                return;
            }

            string a = adminovalista.Items[i].ToString();
            d = a[0].ToString() + a[1].ToString() + a[2].ToString();


            AdminNarudzbe frm = new AdminNarudzbe();
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void Admin_Load(object sender, EventArgs e)
        {
        }
    }
}
