using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssFeeder
{
	public class MyClass
	{
		public MyClass ()
		{
		}

		public List<FeedItem> FeedItems {
			get;
			set;
		}

		private async Task<List<FeedItem>> ParseFeed(string rss)
		{
			return await Task.Run(() =>
				{
					var xdoc = XDocument.Parse(rss);
					var id = 0;
					return (from item in xdoc.Descendants("item")
						select new FeedItem
						{
							Title = (string)item.Element("title"),
							Description = (string)item.Element("description"),
							Link = (string)item.Element("link"),
							PublishDate = (string)item.Element("pubDate"),
							Category = (string)item.Element("category"),
							//ImageUrl = Regex.Matches((string)item.Element("description").Value,"<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase),
							Id = id++
						}).ToList();
				});
		}


//		public async void ViewDidLoad ()
//		{
//
//			var client = new HttpClient ();
//
//			try{
//				var httpClient = new HttpClient();
//				var feed = "http://planet.xamarin.com/feed";
//
//				var responseString = await httpClient.GetStringAsync(feed);
//				if(FeedItems ==null)
//					FeedItems = new List<FeedItem>();
//				FeedItems.Clear();
//				var items = await ParseFeed(responseString);
//				foreach (var item in items)
//				{
//					FeedItems.Add(item);
//				}
//			} catch (Exception ex) {
//
//				//some fucking exception happened, We don't care
//			}
//			// Perform any additional setup after loading the view, typically from a nib.
//		}
	}
}

