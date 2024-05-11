using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetHealth.Models;

namespace Tests
{
    [TestClass]
    public class RequestTest
    {
        [TestMethod]
        public void BelowZeroIdTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Request request = new Request()
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
                Request request = new Request()
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
                Request request = new Request()
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
                Request request = new Request()
                {
                    Name = "asfawsfasfafsfasfasfasfasasfawsfasfafsfasfasfasfas"
				};
            });
        }
        [TestMethod]
        public void TooShortPhoneNumber()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Request request = new Request()
                {
                    PhoneNumber = "1"
                };
            });
        }
        [TestMethod]
        public void TooLongPhoneNumber()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Request request = new Request()
                {
                    PhoneNumber = "12345678901"
                };
            });
        }
    }
}
