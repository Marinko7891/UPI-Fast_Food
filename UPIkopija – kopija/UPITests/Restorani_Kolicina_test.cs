using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UPI.Tests
{
    [TestClass()]
    public class Restorani_Kolicina_test
    {
        [TestMethod()]
        public void KrivaKolicinaMCTest()
        {
            MCDonalds MC = new MCDonalds();

            string kolicina = "br";
            bool provjera = MC.ProvjeriKolicinu(kolicina);
            Assert.IsFalse(provjera);
        }

        [TestMethod()]
        public void KrivaKolicinuMCTest1()
        {
            MCDonalds MC = new MCDonalds();

            string kolicina = "0";
            bool provjera = MC.ProvjeriKolicinu(kolicina);
            Assert.IsFalse(provjera);
        }

        [TestMethod()]
        public void KrivaKolicinuMCTest2()
        {
            MCDonalds MC = new MCDonalds();

            string kolicina = "-5";
            bool provjera = MC.ProvjeriKolicinu(kolicina);
            Assert.IsFalse(provjera);
        }

        [TestMethod()]
        public void IspravnaKolicinaMCTest()
        {
            MCDonalds MC = new MCDonalds();

            string kolicina = "5";
            bool provjera = MC.ProvjeriKolicinu(kolicina);
            Assert.IsTrue(provjera);
        }



    }
}