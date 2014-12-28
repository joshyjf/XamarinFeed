using System;
using UIKit;
using RssFeeder;
using System.Collections.Generic;
using Foundation;
using CoreGraphics;
using System.Drawing;

namespace TestRss
{


	public class TableSource:UITableViewSource
	{
		protected List<FeedItem> feedItems;
		protected string cellIdentifier = "TableCell";
		UIViewController _controller;

		public TableSource (List<FeedItem> items,UIViewController controller)
		{
			_controller = controller;
			feedItems = items;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			Console.WriteLine ("feedItems.Count:" + feedItems.Count);
			return feedItems.Count;
		}
			

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine(String.Format("Row clicked: {0}", indexPath.Row));
			CurrentFeed = feedItems[indexPath.Row];

//			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
//			DetailsViewController controller = (DetailsViewController)board.InstantiateViewController("details");
//			_viewController.PresentViewController (controller, true, null);
			_controller.PerformSegue ("Next",this);
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 100;
		}

		public override UITableViewCell GetCell (UITableView tableView,NSIndexPath indexPath)
		{
			NSUrl url=null;
			NSUrl gravatar=null;
			try
			{
			url = new NSUrl(feedItems [indexPath.Row].ImageUrl);
				//gravatar = new NSUrl(Gravatar.Urls.GetImageUrl(feedItems[indexPath.Row].Gravatar,25));
			}
			catch(Exception){
			}
//
//			CGSize itemSize = new CGSize(120, 100);
//			UIGraphics.BeginImageContext(itemSize);
//
//			UIImage img = string.IsNullOrEmpty(feedItems [indexPath.Row].ImageUrl) || url == null?UIImage.FromFile ("xamarin copy.jpg"):UIImage.LoadFromData(NSData.FromUrl(url));
//			img.Draw(new RectangleF(0,0,120,100));
//
//			cell.ImageView.Image = UIGraphics.GetImageFromCurrentImageContext();
//			cell.ImageView.Layer.MasksToBounds = true;
//			cell.ImageView.Layer.CornerRadius = 10.0F;
//			UIGraphics.EndImageContext();
			var cell = tableView.DequeueReusableCell (cellIdentifier) as CustomTableCell;
			if (cell == null)
				cell = new CustomTableCell (cellIdentifier);

			cell.UpdateCell (feedItems [indexPath.Row].Title
				, "by " + feedItems [indexPath.Row].Author
				, string.IsNullOrEmpty (feedItems [indexPath.Row].ImageUrl) || url == null ?
				UIImage.FromFile ("xamarin copy.jpg") : UIImage.LoadFromData (NSData.FromUrl (url)),
				UIImage.FromFile ("xamarin copy.jpg"));
//				string.IsNullOrEmpty(feedItems [indexPath.Row].Gravatar) || gravatar == null?
//				UIImage.FromFile ("xamarin copy.jpg"):UIImage.LoadFromData(NSData.FromUrl(gravatar)));

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			cell.ImageView.Layer.CornerRadius = 10f;
			//cell.Gravatar.Layer.CornerRadius = 20f;
			cell.ImageView.Layer.MasksToBounds = true;

			cell.BackgroundColor = UIColor.FromRGB(0.96f,0.96f,0.96f);
			return cell;
		}

		public FeedItem CurrentFeed  {
			get;
			set;
		}

	}
}

