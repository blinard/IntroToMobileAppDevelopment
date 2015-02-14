using System;

namespace IntroToMobileAppDevelopment.Xamarin.Presenters
{
	public interface IMainPageView
	{
		event EventHandler OnGetANumberClicked;
		void DisplayNumberMessage (MainPageModel model);
	}
}

