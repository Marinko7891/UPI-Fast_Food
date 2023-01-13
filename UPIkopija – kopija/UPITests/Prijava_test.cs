using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UPI.Tests
{
    [TestClass()]
    public class Prijava_test
    {
        [TestMethod()]

        public void KrivaLozinka()
        {
            Form1 f1 = new Form1();

            string user = "test123";
            string loz = "123";
            bool provjera = f1.Prijava(user, loz);
            Assert.IsFalse(provjera);
        }
        [TestMethod()]
        public void KrivaUsername()
        {
            Form1 f1 = new Form1();

            string user = "dv";
            string loz = "123456789";
            bool provjera = f1.Prijava(user, loz);
            Assert.IsFalse(provjera);
        }
        [TestMethod()]
        public void PraznaPrijava()
        {
            Form1 f1 = new Form1();

            string user = "";
            string loz = "";
            bool provjera = f1.Prijava(user, loz);
            Assert.IsFalse(provjera);
        }
        [TestMethod()]
        public void UspjesnaPrijava()
        {
            Form1 f1 = new Form1();

            string user = "marin";
            string loz = "hajduk123";
            bool provjera = f1.Prijava(user, loz);
            Assert.IsTrue(provjera);
        }

        [TestMethod()]
        public void AdminProvjera()
        {
            Form1 f1 = new Form1();

            string user = "Marinko";
            string loz = "radic123";
            bool provjera = f1.ProvjeraAdmin(user, loz);
            Assert.IsTrue(provjera);
        }






    }
}