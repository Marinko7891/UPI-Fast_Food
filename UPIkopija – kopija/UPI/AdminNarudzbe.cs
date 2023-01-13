using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UPI
{
    public partial class AdminNarudzbe : Form
    {
        public AdminNarudzbe instance;
        public string z;
        public AdminNarudzbe()
        {
            InitializeComponent();
            instance = this;
        }
        public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfod;Integrated Security=True";

        //nakon sta se ucita forma ucitava se lista svih narudzbi
        private void AdminNarudzbe_Load(object sender, EventArgs e)
        {
            BROJ.Text = Admin.instance.d;
            //label3.Text;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select rj.CIJENA,rj.KOLICINA,r.NAZIV,j.NAZIV_JELA,k.korisnicko_ime from jela j full join RESTORAN_JELA rj on rj.ID_JELA=j.ID_JELA full join RESTORAN r on r.ID_RESTORAN = rj.ID_RESTORAN full join NARUDZBA n on n.ID_NARUDZBA = rj.ID_NARUDZBA full join kupac k on k.id_kupac=n.id_kupac where n.ID_NARUDZBA =@ID_NARUDZBA", con);
            cmd.Parameters.AddWithValue("@ID_NARUDZBA", int.Parse(BROJ.Text));
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader.GetString(0) + "\t" + reader.GetString(1) + "\t" + reader.GetString(2) + "\t" + reader.GetString(3));
                label3.Text = reader.GetString(4).ToString();
            }

        }
    }
}
