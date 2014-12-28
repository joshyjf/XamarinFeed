// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace TestRss
{
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIWebView DetailsWebView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DetailsWebView != null) {
				DetailsWebView.Dispose ();
				DetailsWebView = null;
			}
		}
	}
}
