using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace UPI
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public TextBox txtIme;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            txtIme = txtIm;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Registracija form = new Registracija();
            form.Show();


            ///ovde spajanje


        }
        //public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfood_dostava;Integrated Security=True";
        //Data Source=DESKTOP-VF8I284\SQLEXPRESS;Initial Catalog=fastfood;Integrated Security=True
        public string conString = "Data Source=DESKTOP-VF8I284\\SQLEXPRESS;Initial Catalog=fastfod;Integrated Security=True";

        ///provjeravamo jeli admin
        public bool ProvjeraAdmin(string a, string b)
        {
            if (a == "Marinko" && b == "radic123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ako smo unijeli ispravne podatke ubacuje nas u pocetnu stranicu
        public bool Prijava(string a, string b)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select KORISNICKO_IME,LOZINKA FROM KUPAC where KORISNICKO_IME=@KORISNICKO_IME and LOZINKA=@LOZINKA", con);
            cmd.Parameters.AddWithValue("KORISNICKO_IME", a);
            cmd.Parameters.AddWithValue("LOZINKA", b);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                /////ovde radimo novu formu                              
                Pocetna1 form = new Pocetna1();
                form.Show();
                return true;
            }
            else
            {
                MessageBox.Show("Krivo uneseni podaci");
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ProvjeraAdmin(txtIm.Text, txtloz.Text))
            {
                Admin frm = new Admin();
                frm.Show();

            }
            else
            {
                Prijava(txtIm.Text, txtloz.Text);

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click_3(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnne_MouseDown(object sender, MouseEventArgs e)
        {
            txtloz.PasswordChar = '\0';
        }

        private void btnne_MouseUp(object sender, MouseEventArgs e)
        {
            txtloz.PasswordChar = '*';
        }

        private void txtloz_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(1920, 1080);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
