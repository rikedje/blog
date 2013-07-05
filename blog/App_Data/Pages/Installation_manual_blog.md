{blog,setup,howto}

## HOWTO get started
1. Download/get the source from [https://github.com/edjer/edjer_](https://github.com/edjer/edjer_)
1. Modify the default theme to your liking
1. Modify the code to your liking
1. Set the LoadSecretKey in Web.Config to att string with length > 5 or the site wont load
1. Deploy to your provider to your provider
1. Upload your posts
1. Upload your pages

## HOWTO publish posts
1. FTP posts to ~/App_Data/Blog
1. FTP pages to ~/App_Data/Pages
1. FTP images to ~/App_Data/Content/Images

**This is how I publish my posts, all of them**

	// In publish_blog.bat
    pushd
	cd c:\batch
	Invoke-Expression ".\ncftpput -R -u username -p password -d c:\batch\log\ncftpput.log ftp.edje.se /public_html/App_Data/Blog C:\Users\rikard\Dropbox\BlogEdjeSe\Blog\*.* "
	Invoke-Expression ".\ncftpput -R -u username -p password -d c:\batch\log\ncftpput.log ftp.edje.se /public_html/App_Data/Pages C:\Users\rikard\Dropbox\BlogEdjeSe\Pages\*.*"
	Invoke-Expression ".\ncftpput -R -u username -p password -d c:\batch\log\ncftpput.log ftp.edje.se /public_html/Content/Images C:\Users\rikard\Dropbox\BlogEdjeSe\Images\*.*"
	popd

	Invoke-WebRequest http://www.edje.se/home/reload?key=123456789