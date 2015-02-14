using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using IntroToMobileAppDevelopment.Xamarin.Presenters;

namespace IntroToMobileAppDevelopment.Xamarin.Android
{
	[Activity (Label = "IntroToMobileAppDevelopment.Xamarin.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, IMainPageView
	{
		private Button btnGetANumber;
		private TextView tvNumberMessage;
		private MainPagePresenter _presenter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			_presenter = new MainPagePresenter ();
			_presenter.SetView (this);

			btnGetANumber = FindViewById<Button> (Resource.Id.btnGetANumber);
			tvNumberMessage = FindViewById<TextView> (Resource.Id.tvNumberMessage);

			btnGetANumber.Click += (object sender, EventArgs e) => {
				if (OnGetANumberClicked != null)
					OnGetANumberClicked(this, EventArgs.Empty);
			};
		}

		#region IMainPageView implementation

		public event EventHandler OnGetANumberClicked;

		public void DisplayNumberMessage (MainPageModel model)
		{
			tvNumberMessage.Text = model.NumberMessage;
		}

		#endregion
	}
}


