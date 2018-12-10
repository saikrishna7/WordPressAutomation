using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wordpressAutomation;

namespace wordpressTests
{
    [TestClass]
    public class PageTests : WordPressTest
    {
        [TestMethod]
        public void Can_Edit_A_Page()
        {
            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("Sample Page");

            //Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.IsTrue(NewPostPage.IsAt, "Failed to login");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");

        }
    }
}
