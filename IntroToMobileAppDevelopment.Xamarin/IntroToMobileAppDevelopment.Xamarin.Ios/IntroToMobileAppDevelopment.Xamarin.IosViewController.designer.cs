// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace IntroToMobileAppDevelopment.Xamarin.Ios
{
	[Register ("IntroToMobileAppDevelopment_Xamarin_IosViewController")]
	partial class IntroToMobileAppDevelopment_Xamarin_IosViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnGetANumber { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblNumberMessage { get; set; }

		[Action ("btnGetANumber_OnTouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnGetANumber_OnTouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnGetANumber != null) {
				btnGetANumber.Dispose ();
				btnGetANumber = null;
			}
			if (lblNumberMessage != null) {
				lblNumberMessage.Dispose ();
				lblNumberMessage = null;
			}
		}
	}
}
