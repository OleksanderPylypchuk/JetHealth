using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetHealth.Models;

namespace Tests
{
    [TestClass]
    public class TImageTests
    {
        [TestMethod]
        public void BelowZeroIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TImage image = new TImage()
                {
                    Id = -1
                };
            });
        }
        [TestMethod]
        public void ZeroIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TImage image = new TImage()
                {
                    Id = 0
                };
            });
        }
        [TestMethod]
        public void BelowZeroTreatmentIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TImage image = new TImage()
                {
                    TreatmentId = -1
                };
            });
        }
        [TestMethod]
        public void ZeroTreatmentIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TImage image = new TImage()
                {
                    TreatmentId = 0
                };
            });
        }
    }
}
