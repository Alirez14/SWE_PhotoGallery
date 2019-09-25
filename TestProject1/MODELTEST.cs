using BL.Model;
using BL.Models;
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
    }
}