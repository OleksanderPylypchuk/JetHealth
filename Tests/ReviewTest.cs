using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetHealth.Models;

namespace Tests
{
    [TestClass]
    public class ReviewTest
    {
        [TestMethod]
        public void TooLowRatingTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Review review = new Review()
                {
                    Rating = 0
                };
            });
        }
        [TestMethod]
        public void TooHighRatingTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Review review = new Review()
                {
                    Rating = 10
                };
            });
        }
        [TestMethod]
        public void BelowZeroIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Review review = new Review()
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
                Review review = new Review()
                {
                    Id = 0
                };
            });
        }
        [TestMethod]
        public void EmptyName()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Review review = new Review()
                {
                    Name = ""
                };
            });
        }
        [TestMethod]
        public void TooBigName()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Review review = new Review()
                {
                    Name = "asfawsfasfafsfasfasfasfas"
                };
            });
        }
    }
}
