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
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView MainTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MainTableView != null) {
				MainTableView.Dispose ();
				MainTableView = null;
			}
		}
	}
}
