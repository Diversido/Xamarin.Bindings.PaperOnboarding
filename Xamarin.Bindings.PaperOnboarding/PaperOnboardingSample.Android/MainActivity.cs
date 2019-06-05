using System;
using System.Drawing;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Ramotion.Paperonboarding;
using static Android.Views.View;
using Com.Ramotion.Paperonboarding.Listeners;

namespace PaperOnboardingSample.Android
{
	[Activity (Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity, IPaperOnboardingOnRightOutListener
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.activity_main);

			PaperOnboardingPage scr1 = new PaperOnboardingPage ("Hemingway",
					"Hemingway is the best dog",
					Color.DarkOrchid.ToArgb(), Resource.Drawable.banks, Resource.Drawable.key);
			PaperOnboardingPage scr2 = new PaperOnboardingPage ("Banks",
					"Hemingway is a good boy",
					Color.LightSalmon.ToArgb(), Resource.Drawable.hotels, Resource.Drawable.wallet);
			PaperOnboardingPage scr3 = new PaperOnboardingPage ("Stores",
					"I love Hemiongway",
					Color.DarkGoldenrod.ToArgb(), Resource.Drawable.stores, Resource.Drawable.shopping_cart);

			var elements = new PaperOnboardingPage[] { scr1, scr2, scr3 };
			var onBoardingFragment = PaperOnboardingFragment.NewInstance (elements);
			var fragmentTransaction = SupportFragmentManager.BeginTransaction ();
			fragmentTransaction.Add(Resource.Id.fragment_container, onBoardingFragment);
			fragmentTransaction.Commit ();

			onBoardingFragment.SetOnRightOutListener (this);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.menu_main, menu);
			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			int id = item.ItemId;
			if (id == Resource.Id.action_settings)
			{
				return true;
			}

			return base.OnOptionsItemSelected (item);
		}

		private void FabOnClick (object sender, EventArgs eventArgs)
		{
			View view = (View)sender;
		}

		public void OnRightOut ()
		{
			var fragmentTransaction = SupportFragmentManager.BeginTransaction ();
			var bf = new BlankFragment ();
			fragmentTransaction.Replace (Resource.Id.fragment_container, bf);
			fragmentTransaction.Commit ();
		}
	}
}

