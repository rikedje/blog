{edjer}
{edjer,blogengine,firstpost,first}

This first offical post with Edjer. My blogengine. Dead-simple!

### Edjer is a blogenging I wrote to learn ASP.NET MVC

1. Written i ASP.NET MVC
2. LINQ is my new friend
3. Posts are stored in the filesystem as in ~/App_Data/Blog in a database folderhierarki. The folder named YYYY\MM\DD is date the post is written.
4. All posts are written in [Markdown](http://daringfireball.net/projects/markdown/) translated to HTML with [MarkdownSharp](http://code.google.com/p/markdownsharp/)
5. The first two rows in a post are metadata {category} and {tag1,tag2,tag3,tag4,etc)
6. Extra pages are stored in ~/App_Data/Pages, about.md, cv.md etc

### How I publish my posts
- Powershell-script run on my homeserver + triggered when new files appear in my Dropbox, the files are then transfered with FTP and the site is reloaded to cache
- <strike>Republish all files every night (just in case)</strike>

### TODO-list

- Home
1.maxCount on /Home/Index?max=10, default = 20
1. Add link to my Twitter and to my Git-page. No mail och Facebook needed.
- Pages
1. Change the icon for pages to something different from posts
1. <strike>Make it work with /page/page_name or /page/page%20name</strike>
- <strike>Preload all posts and pages in memory</strike>
- <strike>Reload-Url (/reload?key=my-secret-reload-key-from-webconfig ?)</strike>
- <strike>Indexing of categories and tags? Maybe later...</strike>
- Tags
1. handles only Posts, make it handle Pages as well
1. /tag/heatmap
1. /tag/sortbydate
1. /tag/sortbyname
1. /tag/sortbycount
1. Make /tag/tagname as pretty as /home/index, and make it handle all BlogContent
- Create default theme
1. Simplify design CSS
1. Borrow from Leo Babauta
- Simplify HTML
- Clean up the code, remove unused code, files and folder
- <strike>No Config (assume everything), only two settings one is default</strike>
1. <strike>BlogPath: where all data is stored, default is set to "~/App_Data"</strike>
1. <strike>LoadSecretKey is set to "" per default, ie kan run until this is set.</strike>
- RSS
1. Create RSS-feature ( /home/rss ?)
1. Connection to feedburner 
- Publish on GitHub
1. <strike>Clean up App_Data in webproject, a few testingposts + instructions </strike>
1. Clean reloadkey
- To write
1. Blog about tool for iOS
1. Write post how I wrote edjer (step-by-step, File->Project to Build->Publish)
1. Create instruction on howto publish from VS Web Express to your provider
1. Create instruction on howto publish from WebMatrix to your provider
1. Finish HOWTO-get started, put it on GitHub
- Content
1. Migrate content from old blog
- Tools
1. <strike>Find app to iPhone/iPad to make it possible to blog from there</strike>



### HOWTO get started
1. Download/get the source from (link to git)
1. Change style or use the default
1. Copy to your provider (instruction howto do that on page)
1. Upload your first post
1. Etc



   