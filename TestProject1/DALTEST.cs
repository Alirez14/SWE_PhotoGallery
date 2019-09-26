using System;
using System.Text;
using BL.Model;
using DAL;
using BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class DALTEST
    {
        [TestMethod]
        public void Login_Test_null_photgrapher()
        {
            int i = 1234;
            byte[] b = BitConverter.GetBytes(i);
            var login = new Login();
   
            Assert.ThrowsException<BadImageFormatException>(()=>login.authorization("barakatisina@gmail.com", b));
        }
        [TestMethod]
        public void Login_Test_null_photgrapher2()
        {
            int i = 1234;
            byte[] b = BitConverter.GetBytes(i);
            var login = new Login();
   
            Assert.ThrowsException<BadImageFormatException>(()=>login.authorization("barakatisina@gmail.com", b));
        }

        public void Login_Test_null_photgrapher4()
        {
            int i = 1234;
            byte[] b = BitConverter.GetBytes(i);
            var login = new Login();
   
            Assert.ThrowsException<BadImageFormatException>(()=>login.authorization("barakatisina@gmail.com", b));
        }
        [TestMethod]
        public void Login_Test()
        {
            string i = "Sina1371$$";
            byte[] b = Encoding.ASCII.GetBytes(i);
            var login = new Login();
      
            Assert.ThrowsException<BadImageFormatException>(()=>login.authorization("barakatisina@gmail.com", b));
        }
        [TestMethod]
        public void BlExif_Test()
        {
            var model = new BLExif();
            model.CameraMaker = "test";
            Assert.IsNotNull(model.CameraMaker);
        }
        [TestMethod]
        public void BlExif2_Test()
        {
            var model = new BLExif();
            var model2 = new BLPhoto();
            model.CameraMaker = "tester";
            Assert.IsNotNull(model.CameraMaker);
            
        }
    }
}

