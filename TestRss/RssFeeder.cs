using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;

namespace RssFeeder
{
	public class RssFeeder
	{
		public RssFeeder ()
		{
		}

		public List<FeedItem> FeedItems {
			get;
			set;
		}

		private List<FeedItem> ParseFeed(string rss)
		{
//			return await Task.Run(() =>
//				{
//					var xdoc = XDocument.Parse(rss);
//					var id = 0;
//					return (from item in xdoc.Descendants("item")
//						select new FeedItem
//						{
//							Title = (string)item.Element("title"),
//							Description = (string)item.Element("description"),
//							Link = (string)item.Element("link"),
//							PublishDate = (string)item.Element("pubDate"),
//							Category = (string)item.Element("category"),
////							ImageUrl = string.IsNullOrEmpty(Regex.Matches((string)item.Element("description").Value,
////								"<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase)[0].Groups[0].Value)?"":Regex.Matches((string)item.Element("description").Value,
////									"<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase)[0].Groups[0].Value,
//							Id = id++
//						}).ToList();
//				});


					var xdoc = XDocument.Parse(rss);
					var id = 0;
//			foreach (var item in xdoc.Descendants("item")) {
//				var something = Regex.Match ((string)item.Element ("description").Value,
//					"img.+?src=[\"'](.+?)[\"'].+?", RegexOptions.IgnoreCase).Groups [0].Value;
//				if (!string.IsNullOrEmpty(something)) {
//					var strip = something.Substring (10, something.Length-1);
				//}

			//};
					return (from item in xdoc.Descendants("item")
						select new FeedItem
						{
							Gravatar = (string)item.Element("author"),
							Title = ((string)item.Element("title")).Substring(((string)item.Element("title")).IndexOf(":")==-1?0:((string)item.Element("title")).IndexOf(":")+2),
							Description = (string)item.Element("description"),
							Author = ((string)item.Element("title")).Substring(0,((string)item.Element("title")).IndexOf(":")==-1?0:((string)item.Element("title")).IndexOf(":")+2),
							Link = (string)item.Element("link"),
							PublishDate = (string)item.Element("pubDate"),
							Category = (string)item.Element("category"),
							ImageUrl = Regex.Match((string)item.Element("description").Value,
										"<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value,
							//ImageUrl = item.Element("description").Value,
							//"#<\\s*img [^\\>]*src\\s*=\\s*([\"\\'])(.*?)\\1#im",RegexOptions.IgnoreCase).Groups[0].Value,
							Id = id++
						}).ToList();
				
		}


		public List<FeedItem> Load ()
		{

			try {
				var httpClient = new HttpClient ();
				var feed = "http://planet.xamarin.com/feed";

				var responseString = new WebClient().DownloadString(feed);
				if (FeedItems == null)
					FeedItems = new List<FeedItem> ();

				FeedItems.Clear ();

				var items = ParseFeed (responseString);
				foreach (var item in items) {
					FeedItems.Add (item);
				}
			}
			catch (Exception ex) {

				//some exception happened, We don't care
			}
				return FeedItems;
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

