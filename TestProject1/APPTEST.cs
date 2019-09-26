using System;
using System.Text;
using BL.Model;
using BL.Models;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class APPTEST
    {
        
        #region DalTEST
        [TestMethod]
        public void Login_Test()
        {
            string i = "Sina1371$$";
            byte[] b = Encoding.ASCII.GetBytes(i);
            var login = new Login();
            BLPhotographer person = login.authorization("barakatisina@gmail.com", b);
            Assert.IsNotNull(person);
        }
        [TestMethod]
        public void Model_Types()
        {
            var model = new BLPhoto();
            var model2 = new BLPhotographer();
           
            Assert.AreNotEqual(model.GetType(),model2.GetType());
        }
        #endregion



        #region BLTESTDAl

        

     
        [TestMethod]
        public void BlExif_Test()
        {
            var model = new BLExif();
            model.CameraMaker = "test";
            Assert.IsNotNull(model.CameraMaker);
        }
        [TestMethod]
        public void Login_Test_null_photgrapher6()
        {
            int i = 1234;
            byte[] b = BitConverter.GetBytes(i);
            var login = new Login();
   
            Assert.ThrowsException<BadImageFormatException>(()=>login.authorization("barakatisina@gmail.com", b));
        }
        [TestMethod]
        public void BlExif2_Test()
        {
            var model = new BLExif();
            var model2 = new BLPhoto();
            model.CameraMaker = "tester";
            Assert.IsNotNull(model.CameraMaker);
            
        }
        [TestMethod]
        public void Login_Test_null_photgrapher()
        {
            int i = 1234;
            byte[] b = BitConverter.GetBytes(i);
            var login = new Login();
            var person = login.authorization("xxx@xxx.com", b);
            Assert.IsNull(person);
        }
        #endregion
      

          
        #region Test

        [TestMethod]
        public void BLPhotographer_Validation1()
        {
            var dateString = "5/1/2008 8:30:52 AM";
            DateTime date1 = DateTime.Parse(dateString,
                System.Globalization.CultureInfo.InvariantCulture);
            var reg = new Register();
            Action dd = delegate
            {
                reg.AddMember("33", "rtroiuiou", "oidciosdj",
                    "fiojvvij", date1, "efbtzbvrec", "rfrefefege");
            };
            Assert.ThrowsException<BadImageFormatException>(dd);



        }
        
        [TestMethod]
        public void BLPhotographer_Validation2()
        {
            var dateString = "5/1/2008 8:30:52 AM";
            DateTime date1 = DateTime.Parse(dateString,
                System.Globalization.CultureInfo.InvariantCulture);
            var reg = new Register();
            Action dd = delegate
            {
                reg.AddMember("wefkwewknd", "rtroiuiou", "oidciosdj",
                    "fiojvvij", date1, "test", "rfrefefege");
            };
            Assert.ThrowsException<BadImageFormatException>(dd);



        }
        #endregion
        
    }
}