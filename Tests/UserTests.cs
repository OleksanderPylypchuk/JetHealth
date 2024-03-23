using JetHealth.Models;

namespace Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void FirstNameZeroLengthTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = "",
                    LastName = "asdas"
                };
            });
        }
        [TestMethod]
        public void FirstNameTooBigLengthTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = "asdasfasfasfasfasfasfasfasfasf",
                    LastName = "asdas"
                };
            });
        }
        [TestMethod]
        public void LastNameZeroLengthTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = "asdas",
                    LastName = ""
                };
            });
        }
        [TestMethod]
        public void LastNameTooBigLengthTest()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = "sadasf",
                    LastName = "asdasfasfasfasfasfasfasfasfasf"
                };
            });
        }
        [TestMethod]
        public void CorrectTest()
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = "sadasf",
                LastName = "asdasf"
            };
            Assert.IsNotNull(user);
        }
    }
}