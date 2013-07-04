using EdjeBlog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;


namespace EdjeBlog.Utils
{
    public class Repository
    {

        private static List<Post> postsCache = new List<Post>();
        private static List<Page> pagesCache = new List<Page>();
        private static HashSet<string> yearsCache = new HashSet<string>();
        private static Dictionary<string, int> tagsCache = new Dictionary<string, int>(); 
        public static string RepositoryPath { get; set; }

        private static List<BlogContent> contentCache = new List<BlogContent>();

        public static void LoadContent(string path)
        { 
            contentCache.AddRange(LoadPosts(Path.Combine(RepositoryPath, "Blog")));
            contentCache.AddRange(LoadPages(Path.Combine(RepositoryPath, "Pages")));

            foreach (BlogContent bc in contentCache)
            {
                string _year = bc.Date.Substring(0, 4);
                if (!yearsCache.Contains(_year))
                {
                    yearsCache.Add(_year);
                }

                // Build tag-cache
                foreach (var tag in bc.Tags)
                {
                    int value = 0;
                    tagsCache.TryGetValue(tag, out value);
                    tagsCache[tag] = value + 1;
                }
            }

        }

        /// <summary>
        /// Get all content
        /// </summary>
        public static List<BlogContent> GetContent()
        {
            return (from cont in contentCache
                    select cont).ToList();
        }
        /// <summary>
        ///     Init Repository from disk
        /// </summary>
        ///
        public static void Init(string key)
        {
            string keyFromConfig = ConfigurationManager.AppSettings.Get("LoadSecretKey");
            if(keyFromConfig.Length > 5)
            {
                // Clean all caches
                contentCache.Clear();
                tagsCache.Clear();
                yearsCache.Clear();
                // Load em again
                LoadContent(RepositoryPath);
            }
        }
        
        /// <summary>
        ///     Return all posts from cache
        /// </summary>
        /// <param name=""></param>
        /// <returns>List<Post></returns>
        public static List<Post> GetPosts()
        {
            return (from cont in contentCache 
                   where cont.GetType() == typeof(Post)
                   select new Post { Date = cont.Date, Title = cont.Title, Body = cont.Body, Tags = cont.Tags}).ToList();
        }

        public static List<Post> GetPostsForYear(string year)
        {
            return ( from post in GetPosts()
                     where post.Date.Substring(0, 4) == year
                     select post).ToList();
        }
        /// <summary>
        /// Loads all posts from disk to cache
        /// </summary>
        /// <param name="path"></param>
        public static List<Post> LoadPosts(string path)
        {
            List<Post> posts = new List<Post>();
            posts = (from file in new DirectoryInfo(path).GetFiles("*.md", SearchOption.AllDirectories)
                            orderby file.LastWriteTime descending

                            let post = LoadPost(file.FullName)

                            //select new Post { Date = post.Date, Title = post.Title, Body = post.Body, Category = post.Category, Tags = post.Tags }).OrderByDescending(p => p.Date).ToList();
                     select new Post { Date = post.Date, Title = post.Title, Body = post.Body, Tags = post.Tags }).OrderByDescending(p => p.Date).ToList();
                    
            return posts;
        }

        /// <summary>
        /// Get all tags as a Dictionary<string, int>
        /// </summary>
        public static Dictionary<string, int> GetTags()
        {
            return tagsCache;
        }
        
        /// <summary>
        /// Return list of year under BlogPath
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List<string></returns>
        public static List<string> GetArchiveYears()
        {
            return yearsCache.ToList();
        }

 
        /// <summary>
        /// Return a post from storage on disk
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Post post</returns>
        public static Post LoadPost(string path)
        {
            MarkdownSharp.Markdown markdown = new MarkdownSharp.Markdown();

            Post post = new Post();

            FileInfo file = new FileInfo(path);

            post.Date  = String.Join("-", (from d in file.FullName.Split('\\').Reverse().Skip(1).Take(3).Reverse()
                                                      select d));

            post.Title = file.Name.Split('.')[0].Replace('_', ' ');

            string[] fopen = System.IO.File.ReadAllLines(file.FullName);

            // string categoryLine = fopen.FirstOrDefault() ?? "";
            // post.Category = categoryLine.Trim('{', '}');

            string tagLine = fopen.ElementAtOrDefault(1) ?? "";
            post.Tags = from t in tagLine.Trim('{', '}').ToString().Split(',')
                                    select t.Trim();

            post.Body = markdown.Transform(String.Join("\n", fopen.Skip(2).ToArray()));

            return post;
        }
        /// <summary>
        /// Get a post from cache that matches date and title
        /// </summary>
        /// <param name="date"></param>
        /// <param name="title"></param>
        /// <returns>Post post</returns>
        public static Post GetPost(string date, string title)
        {
            return GetPosts().FirstOrDefault(post => post.Date == date && post.Title == title);
        }
        /// <summary>
        /// Load a page from storage on disk
        /// </summary>
        /// <param name="path">Path to Page</param>
        /// <returns>Page page</returns>
        public static Page LoadPage(string path)
        {
            MarkdownSharp.Markdown markdown = new MarkdownSharp.Markdown();

            Page page = new Page();

            FileInfo file = new FileInfo(path);
            
            page.Title = file.Name.Split('.')[0].Replace('_', ' ');

            page.Date = file.LastWriteTime.ToString("yyyy-MM-dd");

            string[] fopen = System.IO.File.ReadAllLines(file.FullName);

            string tagLine = fopen.FirstOrDefault() ?? "";
            page.Tags = from t in tagLine.Trim('{', '}').ToString().Split(',')
                        select t.Trim();

            page.Body = markdown.Transform(String.Join("\n", fopen.Skip(2).ToArray()));

            return page;
        }
        /// <summary>
        /// Get page from cache that matches filename (ie Title)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Page GetPage(string title)
        {
            return GetPages().FirstOrDefault(page => page.Title == title);
        }
        /// <summary>
        /// Get a list of all pages from cache
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Page> GetPages()
        {
            return (from cont in contentCache 
                   where cont.GetType() == typeof(Page)
                   select new Page { Date = cont.Date, Title = cont.Title, Body = cont.Body, Tags = cont.Tags}).ToList();
        }
        /// <summary>
        /// Load all pages from disk to cache
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Page> LoadPages(string path)
        {
            MarkdownSharp.Markdown markdown = new MarkdownSharp.Markdown();

            List<Page> pages = new List<Page>();

            pages = (from file in new DirectoryInfo(path).GetFiles("*.md", SearchOption.AllDirectories)
                     // orderby file.LastWriteTime descending

                     let page = LoadPage(file.FullName)

                     select new Page { Date = page.Date, Title = page.Title, Body = page.Body, Tags = page.Tags }).OrderByDescending(p => p.Date).ToList();
            
            return pages;
        }
    }
}