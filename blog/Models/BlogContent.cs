using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdjeBlog.Models
{
    public class BlogContent
    {
        public string Date { get; set; }                // YYYY-MM-DD
        public string Title { get; set; }               // name of .md file like name_of_post.md
        public string Body { get; set; }                // Body of post i Markdown
        public IEnumerable<string> Tags { get; set; }   // content of second {}, like {tag1, tag2, tag3}
    }
}