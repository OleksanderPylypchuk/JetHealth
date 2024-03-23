using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetHealth.Models;

namespace Tests
{
    [TestClass]
    public class TProceduresTests
    {
        [TestMethod]
        public void BelowZeroIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TProcedure procedure = new TProcedure()
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
                TProcedure procedure = new TProcedure()
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
                TProcedure procedure = new TProcedure()
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
                TProcedure procedure = new TProcedure()
                {
                    TreatmentId = 0
                };
            });
        }
    }
}
