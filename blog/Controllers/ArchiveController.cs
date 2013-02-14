using EdjeBlog.Models;
using EdjeBlog.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace EdjeBlog.Controllers
{
    public class ArchiveController : Controller
    {

        string BlogPath
        {
            get
            {             
                return Server.MapPath(ConfigurationManager.AppSettings.Get("BlogPath") );
            }
        }
        //
        // GET: /Archive/Index

        public ActionResult Index(string year)
        {
            ArchiveIndexViewModel aivm = new ArchiveIndexViewModel();   
         
            string _year;
            _year = year ?? DateTime.Now.Year.ToString();

            aivm.CurrentYear = _year;
            aivm.Posts = Repository.GetPostsForYear(_year);
            aivm.Years = Repository.GetArchiveYears();

            return View(aivm);
        }

        //
        // GET: /Archive/Details?date=YYYY-MM-DD+title=Title of the post

        public ActionResult Details(string date, string title)
        {
            string sb = Utils.Utils.DateTitleToPath(BlogPath,date, title);
            Post post = Repository.GetPost(date, title);             
            return View(post);
        }

       

    }
}
