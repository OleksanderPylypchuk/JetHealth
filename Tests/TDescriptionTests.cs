using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetHealth.Models;

namespace Tests
{
    [TestClass]
    public class TDescriptionTests
    {
        [TestMethod]
        public void BelowZeroIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TDescription description = new TDescription()
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
                TDescription description = new TDescription()
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
                TDescription description = new TDescription()
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
                TDescription description = new TDescription()
                {
                    TreatmentId = 0
                };
            });
        }
    }
}
