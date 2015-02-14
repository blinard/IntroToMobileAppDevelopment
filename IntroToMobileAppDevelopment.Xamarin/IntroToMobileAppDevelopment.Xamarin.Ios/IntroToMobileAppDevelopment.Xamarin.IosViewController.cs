using System;
using System.Drawing;

using Foundation;
using UIKit;
using IntroToMobileAppDevelopment.Xamarin.Presenters;

namespace IntroToMobileAppDevelopment.Xamarin.Ios
{
	public partial class IntroToMobileAppDevelopment_Xamarin_IosViewController : UIViewController, IMainPageView
	{
		private MainPagePresenter _presenter;

		public IntroToMobileAppDevelopment_Xamarin_IosViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			_presenter = new MainPagePresenter ();
			_presenter.SetView (this);
		}

		partial void btnGetANumber_OnTouchUpInside (UIButton sender)
		{
			if (OnGetANumberClicked != null)
				OnGetANumberClicked(this, EventArgs.Empty);
		}

		#region IMainPageView implementation

		public event EventHandler OnGetANumberClicked;

		public void DisplayNumberMessage (MainPageModel model)
		{
			lblNumberMessage.Text = model.NumberMessage;
		}

		#endregion
	}
}

