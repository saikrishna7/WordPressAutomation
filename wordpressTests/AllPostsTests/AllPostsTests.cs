using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using wordpressAutomation;
using wordpressAutomation.WorkFlows;

namespace wordpressTests.AllPostsTests
{
    [TestClass]
    public class AllPostsTests : WordPressTest
    {
        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            // Go to posts, get post count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            // Add a new post
            PostCreator.CreatePost();

            // Go to posts, get new post count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of current posts didn't increase");

            // Check for added post
            Assert.IsTrue(ListPostsPage.DoesPostExistsWithTitle(PostCreator.PreviousTitle));

            // Trash post(clean up)
            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Thread.Sleep(1000);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash the post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            // Create new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Searching posts, title")
                .WithBody("Searching posts, body")
                .Publish();

            // Go to list posts
            ListPostsPage.GoTo(PostType.Posts);

            // Search for post
            ListPostsPage.SearchforPost("Searching posts, title");

            // Check that post shows up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistsWithTitle("Searching posts, title"));

            // Cleanup (Trash post)
            ListPostsPage.TrashPost("Searching posts, title");

        }
    }
}
