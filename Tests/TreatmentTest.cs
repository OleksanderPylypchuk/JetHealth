using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetHealth.Models;

namespace Tests
{
    [TestClass]
    public class TreatmentTest
    {
        [TestMethod]
        public void BelowZeroIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Treatment treatment = new Treatment()
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
                Treatment treatment = new Treatment()
                {
                    Id = 0
                };
            });
        }
        [TestMethod]
        public void BelowZeroTDescriptionIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Treatment treatment = new Treatment()
                {
                    TreatmentDescriptionId = -1
                };
            });
        }
        [TestMethod]
        public void ZeroTDescriptionIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Treatment treatment = new Treatment()
                {
                    TreatmentDescriptionId = 0
                };
            });
        }
    }
}
