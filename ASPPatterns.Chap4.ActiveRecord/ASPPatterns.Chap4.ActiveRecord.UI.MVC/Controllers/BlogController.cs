using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ASPPatterns.Chap4.ActiveRecord.Model;

namespace ASPPatterns.Chap4.ActiveRecord.UI.MVC.Controllers
{
    public class BlogController : Controller
    {        
        // GET: /Blog/
        public ActionResult Index()
        {
            Post[] posts = Post.FindAll();

            if (posts.Count() > 0)
            {
                ViewData["AllPosts"] = posts;
                ViewData["LatestPost"] = Post.FindLastestPost();   
                return View();
            }
            else
            {
                return Create();
            }
        }
        
        // POST: /Blog/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateComment(string Id, FormCollection collection)
        {
            int postId = 0;
            int.TryParse(Id, out postId);
            Post post = Post.Find(postId);

            Comment comment = new Comment();
            comment.Post = post;
            comment.Author = Request.Form["Author"];
            comment.DateAdded = DateTime.Now;
            comment.Text = Request.Form["Comment"];

            comment.Save();

            return Detail(post.Id.ToString());
        }

        // GET: /Blog/Detail/1
        public ActionResult Detail(string Id)
        {
            ViewData["AllPosts"] = Post.FindAll();

            int postId = 0;
            int.TryParse(Id, out postId);

            ViewData["LatestPost"] = Post.Find(postId);

            return View("Index");
        }

        // GET: /Blog/Create
        public ActionResult Create()
        {
            return View("AddPost");
        }

        // POST: /Blog/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Post post = new Post();
            post.DateAdded = DateTime.Now;
            post.Subject = Request.Form["Subject"];
            post.Text = Request.Form["Content"]; ;
            post.Save();

            return Detail(post.Id.ToString());
        }
    }
}
