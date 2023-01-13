using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace UPI
{

    //nevalja
    public partial class Pocetna1 : Form
    {
        Random random = new Random();
        public static Pocetna1 instance;
        public Label lblPro;
        public ListBox listKosarica;
        public ListBox listCijena;
        public ListBox listKolicina;
        public ListBox listre;
        public Label lblUkupn;
        public double zbroj = 0;

        public Pocetna1()
        {
            InitializeComponent();
            instance = this;
            lblPro = lblProfil;
            listKosarica = lstKosara;
            listCijena = LstCij;
            listKolicina = lstKolicina;
            lblUkupn = lblUkupno;
            listre = listres;
        }
        public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfod;Integrated Security=True";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblProfil_Click(object sender, EventArgs e)
        {

        }

        //kada se ucita da bude u ovoj velicini
        private void Pocetna1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(1920, 1080);
            lblPro.Text = Form1.instance.txtIme.Text;
        }

        private void btnMek_Click(object sender, EventArgs e)
        {
            MCDonalds mcDon = new MCDonalds();
            mcDon.Show();
        }

        private void btnKFC_Click(object sender, EventArgs e)
        {
            KFC kfc = new KFC();
            kfc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Burger_King bur = new Burger_King();
            bur.Show();
        }

        private void btnPivac_Click(object sender, EventArgs e)
        {
            Bili_Pivac bili = new Bili_Pivac();
            bili.Show();
        }

        private void btnPopaj_Click(object sender, EventArgs e)
        {
            Popaj pop = new Popaj();
            pop.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Medeni med = new Medeni();
            med.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MojProfil moj = new MojProfil();
            moj.Show();
        }
        ///id kupac
        //saljemo restoran_jela u bazu
        public void SaljiResJela(int ID_RES, int ID_JELA, int ID_NARUDZBA, string kolicina, string cijena)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string q = "INSERT INTO RESTORAN_JELA(ID_RESTORAN,ID_JELA,ID_NARUDZBA,KOLICINA,CIJENA) VALUES('" + ID_RES + "','" + ID_JELA + "','" + ID_NARUDZBA + "','" + kolicina + "','" + cijena + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool ProvjeriKosaricu(ListBox a)
        {
            if (a.Items.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!ProvjeriKosaricu(lstKosara))
            {
                MessageBox.Show("Niste nista stavili u kosaricu");
            }
            else
            {
                string idkupac = "";
                string idNarudzba = "";
                //id slucajnog dobavljaca
                int ID_DOB = random.Next(1, 4);
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand("select ID_KUPAC FROM KUPAC where KORISNICKO_IME=@KORISNICKO_IME", con);
                    cmd.Parameters.AddWithValue("KORISNICKO_IME", Pocetna1.instance.lblProfil.Text);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        idkupac = reader["id_kupac"].ToString();
                        reader.Close();
                        con.Close();
                    }
                    con.Open();
                    ///saljemo narudzbu u bazu
                    string q = "INSERT INTO NARUDZBA(DATUM,CIJENA,ID_KUPAC,ID_DOSTAVLJAC) VALUES('" + DateTime.Now + "','" + lblUkupn.Text + "','" + int.Parse(idkupac) + "','" + ID_DOB + "')";
                    SqlCommand cmd1 = new SqlCommand(q, con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Uspješno potvrdena narudzba");

                    con.Open();
                    //SqlCommand cmd2 = new SqlCommand("select ID_NARUDZBA FROM NARUDZBA where ID_KUPAC=@ID_KUPAC and ID_DOSTAVLJAC=@ID_DOSTAVLJAC and CIJENA=@CIJENA", con);
                    SqlCommand cmd2 = new SqlCommand("select max(id_narudzba) from NARUDZBA where id_kupac=@id_kupac", con);


                    cmd2.Parameters.AddWithValue("ID_KUPAC", idkupac);
                    //cmd2.Parameters.AddWithValue("ID_DOSTAVLJAC", ID_DOB);
                    //cmd2.Parameters.AddWithValue("CIJENA", lblUkupn.Text);
                    SqlDataReader reader1;
                    reader1 = cmd2.ExecuteReader();
                    if (reader1.Read())
                    {
                        //idNarudzba = reader1["max(ID_NARUDZBA)"].ToString();
                        idNarudzba = reader1.GetInt32(0).ToString();
                        //MessageBox.Show(idNarudzba.ToString());
                        //MessageBox.Show(idNarudzba);
                        reader.Close();
                        con.Close();
                    }

                }



                int ID_RES;
                int a = listKosarica.Items.Count;
                //MessageBox.Show(a.ToString());
                //nakon sto smo poslali narudzbu
                ///ovde saljemo u restoran jela
                for (int i = 0; i < a; i++)
                {
                    int ID_MEK;
                    string u = listKosarica.Items[i].ToString();
                    string o = listKolicina.Items[i].ToString();
                    string p = listCijena.Items[i].ToString();
                    string r = listres.Items[i].ToString();
                    if (r == "McDonalds")
                    {
                        ID_RES = 12;
                        if (u == "Chicken Box")
                        {
                            ID_MEK = 1;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Chicken McNuggets 20 kom")
                        {
                            ID_MEK = 2;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Big Tasty Bacon")
                        {
                            ID_MEK = 3;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "McWrap Crispy Chicken")
                        {
                            ID_MEK = 4;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Chicken strips 3 komada")
                        {
                            ID_MEK = 5;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "McToast sa sirom i slaninom")
                        {
                            ID_MEK = 6;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                    }
                    else if (r == "MEDENI")
                    {
                        ID_RES = 13;
                        if (u == "Pizza Miješana")
                        {
                            ID_MEK = 31;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);

                        }
                        else if (u == "Pizza 4 sira")
                        {
                            ID_MEK = 32;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Pizza Medeni")
                        {
                            ID_MEK = 33;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Pizza Vegetarijanska")
                        {
                            ID_MEK = 34;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Sendvič sir sa šunkom u tijestu")
                        {
                            ID_MEK = 35;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Tortilla tunjevina")
                        {
                            ID_MEK = 36;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }

                    }
                    else if (r == "POPAJ")
                    {
                        ID_RES = 14;
                        if (u == "Pizza Miješana")
                        {
                            ID_MEK = 25;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Pizza Plodovi mora")
                        {
                            ID_MEK = 26;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Sendvič sir šunka u pecivu")
                        {
                            ID_MEK = 27;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Sendvič sir pršut u pecivu")
                        {
                            ID_MEK = 28;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Povrće sa žara")
                        {
                            ID_MEK = 29;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Mješano meso meni")
                        {
                            ID_MEK = 30;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                    }
                    else if (r == "BILI PIVAC")
                    {
                        ID_RES = 15;
                        if (u == "Tortilla piletina")
                        {
                            ID_MEK = 19;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Sendvič sa piletinom i sirom u tijestu")
                        {
                            ID_MEK = 20;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Hamburger")
                        {
                            ID_MEK = 21;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Ćevapčići")
                        {
                            ID_MEK = 22;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Pohana punjena piletina")
                        {
                            ID_MEK = 23;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Salata piletina")
                        {
                            ID_MEK = 24;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                    }
                    else if (r == "BURGER KING")
                    {
                        ID_RES = 16;
                        if (u == "Monster Burger")
                        {
                            ID_MEK = 13;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Winter Burger")
                        {
                            ID_MEK = 14;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Vegan Sliders")
                        {
                            ID_MEK = 15;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Avocado Vegan Single")
                        {
                            ID_MEK = 16;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Smokehouse Burger Single")
                        {
                            ID_MEK = 17;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "French Burger Double")
                        {
                            ID_MEK = 18;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                    }
                    else if (r == "KFC")
                    {
                        ID_RES = 17;
                        if (u == "5 Komada Kentucky Piletine")
                        {
                            ID_MEK = 7;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Classic Košara")
                        {
                            ID_MEK = 8;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Grander Burger")
                        {
                            ID_MEK = 9;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Qurrito Box")
                        {
                            ID_MEK = 10;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Cheseeburger box")
                        {
                            ID_MEK = 11;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                        else if (u == "Strips Deluxe Box")
                        {
                            ID_MEK = 12;
                            SaljiResJela(ID_RES, ID_MEK, int.Parse(idNarudzba), o, p);
                        }
                    }

                }
            }

        }

        //ovo sluzi za uklanjanje jela
        private void button1_Click(object sender, EventArgs e)
        {
            int a = lstKosara.SelectedIndex;
            if (a > -1)
            {
                string b = lblUkupno.Text;
                string c = LstCij.Items[a].ToString();
                double d = double.Parse(b) - double.Parse(c);
                //MessageBox.Show(b+"-"+c+" =" +d);
                lblUkupno.Text = d.ToString();
                zbroj = zbroj - double.Parse(c);
                lstKosara.Items.RemoveAt(a);
                lstKolicina.Items.RemoveAt(a);
                LstCij.Items.RemoveAt(a);
                listres.Items.RemoveAt(a);

            }
            else
            {
                MessageBox.Show("Niste odabrali sta zelite izbaciti iz kosarice");
            }

        }
    }
}
