using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using EdjeBlog.Models;
using EdjeBlog.Utils;
using System.Configuration;

namespace EdjeBlog.Controllers
{
    public class HomeController : Controller
    {

        string BlogPath
        {
            get { return Server.MapPath(ConfigurationManager.AppSettings.Get("BlogPath")); }
        }
        //
        // GET: /Home/Index and /Home
        public ActionResult Index()
        {
            IEnumerable<Post> posts = Repository.GetPosts(); 
            return View(posts);
        }
        
        //
        // GET: /Home/Category?category=xxx
        public ActionResult Category(string category)
        {
            IEnumerable<Post> posts = Repository.GetPosts().Where(p => p.Category == category);
            return View("Index", posts);
        }

        // GET: /Home/Reload?key=secret-reloadkey
        public ActionResult Reload(string key)
        {
            // Reload posts if key is ok
            Repository.Init(key);

            IEnumerable<Post> posts = Repository.GetPosts();

            return View("Index", posts);
        }
    }
}
