using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPI;

namespace UPITests
{
    public class MojProfil_Test
    {
        [TestMethod()]
        public void LozinkeSeNePodudaraju()
        {
            MojProfil mp = new MojProfil();

            string a = "aaa";
            string b = "bbb";
            bool provjera = mp.ProvjeriIspravnostLoz(a, b);
            Assert.IsFalse(provjera);
        }

        [TestMethod()]
        public void LozinkeSePodudaraju()
        {
            MojProfil mp = new MojProfil();

            string a = "aaa";
            string b = "aaa";
            bool provjera = mp.ProvjeriIspravnostLoz(a, b);
            Assert.IsTrue(provjera);
        }
    }
}
