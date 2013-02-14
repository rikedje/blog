using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdjeBlog.Models
{
    public class ArchiveIndexViewModel
    {
        public List<Post> Posts { get; set; }
        public List<string> Years { get; set; }
        public string CurrentYear { get; set; }
    }
}