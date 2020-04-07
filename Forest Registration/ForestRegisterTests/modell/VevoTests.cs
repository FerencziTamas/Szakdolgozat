using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forest_Register.modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell.Tests
{
    [TestClass()]
    public class VevoTests
    {
        [TestMethod()]
        public void isValidNameNagyBetuvelKezdodikTest(string vevoNev)
        {
            try
            {
                Vevo v = new Vevo(1,"Teszt Feri","Itthon 3", "tech4",78277);
                if (!v.isValid())
                {
                    Assert.IsTrue(true);
                }
            }
            catch (HibasVevoNevException hvne)
            {
                if(hvne.Message != "A név nem nagy betűvel kezdődik")
                {
                    Assert.Fail("A név nagy betűvel kezdődik, még is hibát dob.");
                }
            }
            catch (Exception e)
            {
                
            }
        }
    }
}