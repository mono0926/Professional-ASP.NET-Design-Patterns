using System.ServiceModel;
using System.ServiceModel.Activation;
using ASPPatterns.Chap9.PredictiveFetch.Model;
using System.Collections.Generic;

namespace ASPPatterns.Chap9.PredictiveFetch.UI.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements
        (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BlogService
    {
        // Add [WebGet] attribute to use HTTP GET
        [OperationContract]
        public List<Comment> GetCommentsFor(long postId)
        {
            // Simulates a long running task
            System.Threading.Thread.Sleep(3000);

            List<Comment> posts = new List<Comment>();

            posts.Add(new Comment { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut nibh lorem, pharetra ut bibendum eu, vulputate a neque. Maecenas fermentum, sem in dapibus posuere, eros dolor pharetra orci, quis posuere velit sapien sit amet arcu. Donec sollicitudin odio in eros auctor pellentesque." });             
            posts.Add(new Comment { Text = "Suspendisse ut faucibus mi. Proin non ante felis, ut imperdiet nulla. Nulla et arcu turpis. Sed nisl augue, laoreet ac placerat eu, dictum mattis erat. Nulla dictum, ipsum sed porttitor tincidunt, quam enim faucibus erat, sed feugiat sapien ligula ut justo. Aliquam nec nulla nunc. Donec at lectus lectus."});
            posts.Add(new Comment { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ullamcorper dapibus velit. Vestibulum diam lorem, pulvinar iaculis rutrum sagittis, pellentesque eu ipsum. Sed et augue quis tellus vestibulum luctus. Nullam suscipit diam eu lorem mollis auctor in in purus. Ut lacinia ultrices justo, a tempus sem aliquet ut. Cras eget nulla orci. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. " });
            posts.Add(new Comment { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ullamcorper dapibus velit. Vestibulum diam lorem, pulvinar iaculis rutrum sagittis, pellentesque eu ipsum. Sed et augue quis tellus vestibulum luctus. Nullam suscipit diam eu lorem mollis auctor in in purus." });

            return posts;
        }        
    }
}
