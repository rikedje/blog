using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EdjeBlog.Utils;
using EdjeBlog.Models;

namespace EdjeBlog.Controllers
{
    public class TagController : Controller
    {
        //
        // GET: /Tag/

        public ActionResult Index()
        {
            return View(Utils.Repository.GetTags());
        }

        //
        // GET: /Tag/Tag?tag=xxx
        public ActionResult Tag(string tag)
        {
            IEnumerable<BlogContent> bc = Repository.GetContent().Where(p => p.Tags.Contains(tag));
            return View(bc);
        }
    }
}
