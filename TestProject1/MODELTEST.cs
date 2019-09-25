using System;
using BL.Model;
using BL.Models;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class MODELTEST
    {
        [TestMethod]
        public void BlExif_Test()
        {
            var model = new BLExif();
            model.CameraMaker = "test";
            Assert.IsNotNull(model.CameraMaker);
        }
        [TestMethod]
        public void BlPhoto_Test()
        {
            var model = new BLPhoto();
           
            Assert.AreEqual(model.GetType(),typeof(BLPhoto));
        }
        [TestMethod]
        public void Model_Types()
        {
            var model = new BLPhoto();
            var model2 = new BLPhotographer();
           
            Assert.AreNotEqual(model.GetType(),model2.GetType());
        }

        #region BLPhotoGrapher

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
        

        #endregion
    }
}