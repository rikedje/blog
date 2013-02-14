using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EdjeBlog.Models;
using EdjeBlog.Utils;
using System.Configuration;

namespace EdjeBlog.Controllers
{
    public class PageController : Controller
    {

        //
        // GET: /Page/
        public ActionResult Index()
        {
            List<Page> pages = Repository.GetPages();
            return View(pages);
        }

        // GET: /page/page_name
        public ActionResult Details(string title)
        {
            Page page = Repository.GetPage(title);
            return View(page);
        }

        //
        // GET: /page/tag/tagname
        public ActionResult Tag(string tag)
        {
            IEnumerable<Page> pages = Repository.GetPages().Where(p => p.Tags.Contains(tag));
            return View("Index", pages);
        }

    }
}
