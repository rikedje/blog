using EdjeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EdjeBlog.Utils
{
    public class Utils
    {
        /// <summary>
        /// Converts YYYY-MM-DD to YYYY\\MM\\DD
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateToPath(string date)
        {
            string[] _date = date.Split('-');
            return _date[0] + "\\" + _date[1] + "\\" + _date[2];
        }

        
        /// <summary>
        /// Converts C:\\Path\\To\\Blog\\YYYY\\MM\\DD to YYYY-MM-DD 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string PathToDateString(string path)
        {
            string _path = String.Join("-", (from d in path.Split('\\').Reverse().Skip(1).Take(3).Reverse()
                              select d));

            return _path;
        }

        public static string TitleToFilename(string title)
        {
            return title.Replace(' ', '_') + ".md";
        }
        public static string FilenameToTitle(string filename)
        {
            return filename.Split('.')[0].Replace('_', ' ');
        }

        public static string DateTitleToPath(string rootPath, string date, string title)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(rootPath);
            sb.Append("\\");
            sb.Append(DateToPath(date));
            sb.Append("\\");
            sb.Append(TitleToFilename(title));
            return sb.ToString();
        }
    }
}