using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace TestRss
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			try {
				UIApplication.Main (args, null, "AppDelegate");

			} catch (Exception ex) {
				UIAlertView alert = new UIAlertView();
				alert.Title = "Error";
				alert.AddButton("OK");
				alert.Message = "oops something went wrong...";
				alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
				alert.Show();
			}
		}
	}
}
