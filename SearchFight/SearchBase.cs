using System;
using System.Net;
using System.IO;
using System.Text;

namespace SearchFight
{
    class SearchBase
    {
        public string Gadrress = "https://www.google.com/search?gl=us&hl=en&pws=0&q=";

        public string Yadrress = "https://search.yahoo.com/search?p=";
        public string Yadrress2 = "&fr=yfp-t&fp=1&toggle=1&cop=mss&ei=UTF-8";

        public string Badrress = "https://www.bing.com/search?q=";

        public String GoogleQuery(String query)
        {
            string uri = Gadrress + WebUtility.UrlEncode(query);
            string tag = "<div id=\"resultStats\">";
            int index;
            int subex;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader s = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string result = s.ReadToEnd();
            subex = result.IndexOf(tag);
            index = subex + tag.Length;
            result = result.Substring(index);
            index = result.IndexOf("About ") + 6;
            result = result.Substring(index);
            index = result.IndexOf(" ");
            result = result.Substring(0, index);

            result = result.Replace(",", "");


            return result;
        }

        public String BingQuery(String query)
        {
            string uri = Badrress + WebUtility.UrlEncode(query);
            string tag = "<span class=\"sb_count\">";
            int index;
            int subex;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader s = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string result = s.ReadToEnd();
            subex = result.IndexOf(tag);
            index = subex + tag.Length;
            result = result.Substring(index);
            index = result.IndexOf(" ");
            result = result.Substring(0, index);

            result = result.Replace(".", "");


            return result;
        }

    }
}
