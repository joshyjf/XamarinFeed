using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using RssFeeder;
using System.Drawing;

namespace TestRss
{
	partial class DetailsViewController : UIViewController
	{
		public DetailsViewController (IntPtr handle) : base (handle)
		{
		}

		public FeedItem CurrentFeed {
			get;
			set;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			string url = CurrentFeed.Link;
			DetailsWebView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

		}
	
	}
}
