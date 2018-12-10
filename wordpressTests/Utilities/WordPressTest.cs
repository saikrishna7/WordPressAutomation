using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordpressAutomation;

namespace wordpressTests
{
    public class WordPressTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("sai").WithPassword("password").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //Driver.close();
        }
    }
}
