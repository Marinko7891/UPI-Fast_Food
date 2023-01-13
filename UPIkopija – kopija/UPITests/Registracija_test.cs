using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPI;
namespace UPITests
{
    [TestClass]
    public class Registracija_test

    {
        [TestMethod]
        public void KrivoImeReg()
        {
            Registracija r1 = new Registracija();
            string user = "he";
            string loz = "hajduksplit";
            string email = "marin@gmail.com";
            string tel = "093526467";
            string adresa = "Hajduk";
            bool provjera = r1.Registriraj(user, loz, email, tel, adresa);
            Assert.IsFalse(provjera);
        }

        [TestMethod()]
        public void KrivaLozReg()
        {
            Registracija r1 = new Registracija();
            string user = "MarinBrat";
            string loz = "hajdu";
            string email = "marin@gmail.com";
            string tel = "093526467";
            string adresa = "Hajduk";
            bool provjera = r1.Registriraj(user, loz, email, tel, adresa);
            Assert.IsFalse(provjera);
        }

        [TestMethod()]
        public void KriviEmailReg()
        {
            Registracija r1 = new Registracija();
            string user = "Ivana";
            string loz = "hajduksplit";
            string email = "marin";
            string tel = "093526467";
            string adresa = "Hajduk";
            bool provjera = r1.Registriraj(user, loz, email, tel, adresa);
            Assert.IsFalse(provjera);
        }
        [TestMethod()]
        public void KriviTelReg()
        {
            Registracija r1 = new Registracija();
            string user = "Ivana";
            string loz = "hajduksplit";
            string email = "marin@gmail.com";
            string tel = "hajduk";
            string adresa = "Hajduk";
            bool provjera = r1.Registriraj(user, loz, email, tel, adresa);
            Assert.IsFalse(provjera);
        }

        [TestMethod()]
        public void DobraReg()
        {
            Registracija r1 = new Registracija();
            string user = "Ivana";
            string loz = "hajduksplit";
            string email = "marin@gmail.com";
            string tel = "094356365";
            string adresa = "Hajduk";
            bool provjera = r1.Registriraj(user, loz, email, tel, adresa);
            Assert.IsTrue(provjera);
        }

    }
}
