using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UPI
{
    ///nevalja
    public partial class Narudzbe : Form
    {
        public Narudzbe()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfod;Integrated Security=True";

        //nakon sta se ucita forma ucitava se odma listbox sa svim narudzbaa ulogiranog kupca
        private void Narudzbe_Load(object sender, EventArgs e)
        {
            LBLNAR.Text = MojProfil.instance.d;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select rj.CIJENA,rj.KOLICINA,r.NAZIV,j.NAZIV_JELA from jela j full join RESTORAN_JELA rj on rj.ID_JELA=j.ID_JELA full join RESTORAN r on r.ID_RESTORAN = rj.ID_RESTORAN full join NARUDZBA n on n.ID_NARUDZBA = rj.ID_NARUDZBA where n.ID_NARUDZBA =@ID_NARUDZBA", con);
            cmd.Parameters.AddWithValue("@ID_NARUDZBA",int.Parse(LBLNAR.Text));
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listazadnja.Items.Add(reader.GetString(0) + "\t" + reader.GetString(1) + "\t" + reader.GetString(2) + "\t" + reader.GetString(3));
            }


        }
    }
}
