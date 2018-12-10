using OpenQA.Selenium;
using System;
using System.Threading;
using wordpressAutomation;

namespace wordpressTests
{
    public class NewPostPage
    {
        public static bool IsAt
        {
            get
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h1s.Count > 0)
                    return h1s[0].Text == "Edit Page";
                return false;
            }
        }

        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
              var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            var publish = Driver.Instance.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/div[3]/h1"));
            Console.WriteLine("publish text: "+publish.Text);
            if (publish.Text == "update")

                return true;
            return false;
        }

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);
            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.FindElement(By.Id("publish")).Click();
            Driver.Wait(TimeSpan.FromSeconds(1));
        }
    }
}