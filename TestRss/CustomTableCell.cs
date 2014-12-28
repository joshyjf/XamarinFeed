using System;
using UIKit;
using System.Drawing;
using CoreGraphics;

namespace TestRss
{
	public class CustomTableCell:UITableViewCell
	{

		public CustomTableCell (string identifier):base(UITableViewCellStyle.Default,identifier)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			Image = new UIImageView ();
			Gravatar = new UIImageView ();
			Title = new UILabel () {
				Font = UIFont.FromName ("AvenirNext-Regular", 14f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear,
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0
			};
			Author = new UILabel () {
				Font = UIFont.FromName ("AvenirNext-UltraLight", 12f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				TextAlignment = UITextAlignment.Left,
				BackgroundColor = UIColor.Clear
			};

			ContentView.AddSubviews (new UIView[] { Title,Author, Image,Gravatar });

		}

		public void UpdateCell (string title, string author, UIImage image,UIImage gravatar)
		{
			ImageView.Image = image;
			Title.Text = title;
			Author.Text = author;
			Gravatar.Image = gravatar;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			CGRect contentRect = this.ContentView.Bounds;
			nfloat boundsX = contentRect.X;
			CGRect frame;

			frame = new CGRect(boundsX+10 ,5, 85, 85);
			ImageView.Frame = frame;

			frame= new CGRect(boundsX+100 ,0, 200, 65);
			Title.Frame = frame;

			frame = new CGRect(boundsX+100 ,67, 20, 20);
			Gravatar.Frame = frame;
			Gravatar.Layer.CornerRadius = 20f;

			frame= new CGRect(boundsX+130 ,75, 140, 10);
			Author.Frame = frame;
		}


		public  UIImageView Image {
			get;
			set;
		}

		public UILabel Title {
			get;
			set;
		}

		public  UILabel Author {
			get;
			set;
		}
			
		public UIImageView Gravatar {
			get;
			set;
		}

	}
}

