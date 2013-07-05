{blog}
## This page describes how edjer_ was built


### Getting started
1. Download and install [Visual Studio Express 2012 (Includes ASP.NET MVC4)](http://www.asp.net/mvc)
1. File -> New Project.. | ASP.NET MVC 4 Application | Name: Edjer | **[OK]** 
1. Select Project Template _Empty_ | **[OK]**

### The Model
1. Add the model class for _Posts_.
1. Right Click _Models_ | Add Class... | Name: _Post.cs_ | **[OK]**
1. Make the file Post.cs look like this

		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Web;	
		namespace Edjer.Models
		{
		    public class Post
		    {
		        public Post()
		        {
		            Date = "";
		            Title = "";
		            Body = "";
		            Category = "";
		            //Tags = new IEnumerable<string>();   
		        }
		        public string Date { get; set; }                // YYYY-MM-DD
		        public string Title { get; set; }               // name of .md file like name_of_post.md
		        public string Body { get; set; }                // Body of post i Markdown
		        public string Category { get; set; }            // content of first {}, like {category}
		        public IEnumerable<string> Tags { get; set; }   // content of second {}, like {tag1, tag2, tag3}
		    }
		}

1. Add the model class for _Pages_.
1. Right Click _Models_ | Add Class... | Name: _Page.cs_ | **[OK]**
1. Make the file Page.cs look like this

		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Web;
		namespace Edjer.Models
		{
        	public class Page
			{
			    public Page()
			    {
			        Date = "";
			        Title = "";
			        Body = "";
			        PageFileName = "";
			    }   
			    public string Date { get; set; }       // YYYY-MM-DD
			    public string Title { get; set; }
			    public string Body { get; set; }
			    public IEnumerable<string> Tags { get; set; }
			    public string PageFileName { get; set; }
			}
		}
