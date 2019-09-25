using System;
using System.Text;
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
            var person = login.authorization("xxx@xxx.com",b );
            Assert.IsNull(person);
        }
        [TestMethod]
        public void Login_Test()
        {
            string i ="Sina1371$$" ;
            byte[] b = Encoding.ASCII.GetBytes(i);
            var login = new Login();
            BLPhotographer person = login.authorization("barakatisina@gmail.com",b );
            Assert.IsNull(person);
        }
    }
}