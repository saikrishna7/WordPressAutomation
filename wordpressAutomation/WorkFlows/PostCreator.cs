using System;
using wordpressTests;

namespace wordpressAutomation.WorkFlows
{
    public class PostCreator
    {
        public static void CreatePost()
        {
            NewPostPage.GoTo();
            PreviousBody = CreateBody();
            PreviousTitle = CreateTitle();

            NewPostPage.CreatePost(PreviousTitle).WithBody(PreviousBody).Publish();
        }

        public static string PreviousTitle { get; set; }
        public static string PreviousBody { get; set; }
    }
}