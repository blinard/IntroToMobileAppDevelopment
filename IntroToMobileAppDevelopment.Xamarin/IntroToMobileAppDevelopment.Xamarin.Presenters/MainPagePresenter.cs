using System;
using System.Net.Http;

namespace IntroToMobileAppDevelopment.Xamarin.Presenters
{
	public class MainPagePresenter
	{
		private IMainPageView _view;

		public MainPagePresenter ()
		{
		}

		public void SetView(IMainPageView view) 
		{
			_view = view;
			_view.OnGetANumberClicked += HandleOnGetANumberClicked;
		}

		protected async void HandleOnGetANumberClicked (object sender, EventArgs e)
		{
			string number = "-1";

			//Get the number
			var client = new HttpClient (new ModernHttpClient.NativeMessageHandler ());
			client.DefaultRequestHeaders.Accept.TryParseAdd ("application/json");
			number = await client.GetStringAsync ("http://introtomobileappdevelopment.azurewebsites.net/api/RandomNumber");

			_view.DisplayNumberMessage(new MainPageModel() { NumberMessage = "Your number is\n" + number });
		}
	}
}

