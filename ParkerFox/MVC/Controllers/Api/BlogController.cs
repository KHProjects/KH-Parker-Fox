using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC.Controllers.Api
{
    public class BlogController : ApiController
    {
        public IEnumerable<Post> GetPost(int blogId, int postId)
        {
            return new List<Post>();
        }
    }

    public class Post
    {
        public string Title { get; set; }
    }
}
