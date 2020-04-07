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
    public class ErdogazdalkodoTests
    {
        [TestMethod()]
        public void isValidNameNagyBetuvelKezdodikTest()
        {
            try
            {
                Erdogazdalkodo v = new Erdogazdalkodo("Eg", "Teszt Feri", "Itthon 3");
                if (!v.isValid())
                {
                    Assert.IsTrue(true);
                }
            }
            catch (HibasErGazNevException hvne)
            {
                if (hvne.Message != "A név nem nagy betűvel kezdődik")
                {
                    Assert.Fail("A név nagy betűvel kezdődik, még is hibát dob.");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("A név nagy betűvel kezdődik, még is hibát dob.");
            }
        }

        [TestMethod()]
        public void isValidNagyBetuvelKezdodikCimTeszt()
        {
            try
            {
                Erdogazdalkodo v = new Erdogazdalkodo("Eg", "Teszt Feri", "Itthon 3");
                if (!v.isValid())
                {
                    Assert.IsTrue(true);
                }
            }
            catch (HibasErGazCimException hvce)
            {
                if (hvce.Message != "A cim nem nagy betűvel kezdődik.")
                {
                    Assert.Fail("A cím nagy betűvel kezdődik, még is hibát dob.");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("A cím nagy betűvel kezdődik, még is hibát dob.");
            }
        }


        [TestMethod()]
        public void isValidNemUresTest()
        {
            try
            {
                Erdogazdalkodo v = new Erdogazdalkodo("EG", "Teszt Feri", "Itthon 3");
                if (v.isValid())
                {

                }
            }
            catch
            {
                Assert.Fail("Ne hagyja üresen a mezőt");
            }
        }
    }
}