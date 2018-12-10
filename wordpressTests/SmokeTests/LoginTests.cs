using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wordpressTests
{
    [TestClass]
    public class LoginTests : WordPressTest
    {
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");
        }
    }
}