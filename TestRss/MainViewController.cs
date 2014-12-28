using System;
using Foundation;
using UIKit;
using RssFeeder;
using System.CodeDom.Compiler;

namespace TestRss
{
	partial class MainViewController : UIViewController
	{
		public MainViewController (IntPtr handle) : base (handle)
		{
		}

		public  override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
				MainTableView.Source = new TableSource((new RssFeeder.RssFeeder().Load()),this);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			if (segue.Identifier == "Next") {
				DetailsViewController controller = (DetailsViewController)segue.DestinationViewController;
				controller.CurrentFeed = ((TableSource)MainTableView.Source).CurrentFeed;
			}
		}
	}
}
