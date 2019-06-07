using Foundation;
using System;
using UIKit;
using CoreGraphics;
using PaperOnboardingXamarin.IOS;

namespace PaperOnboardingSample.IOS
{
	public partial class ViewController : UIViewController, IPaperOnboardingDataSource, IPaperOnboardingDelegate
	{
		OnboardingItemInfoObjC[] items = new OnboardingItemInfoObjC[]
		{
			new OnboardingItemInfoObjC(informationImage: UIImage.FromFile("banks.png"),
						   title: "Banks",
						   description: "All dogs are good",
						   pageIcon: UIImage.FromFile("wallet.png"),
						   color: new UIColor(red: 0.4f, green: 0.56f, blue: 0.71f, alpha: 1.00f),
						   titleColor: UIColor.White,
						   descriptionColor: UIColor.White,
						   titleFont: UIFont.PreferredBody,
						   descriptionFont: UIFont.PreferredSubheadline,
						   descriptionLabelPadding: 0,
						   titleLabelPadding: 0),

		new OnboardingItemInfoObjC(informationImage: UIImage.FromFile("hotels.png"),
						   title: "Hotels",
						   description: "All dogs are good",
						   pageIcon: UIImage.FromFile("key.png"),
						   color: new UIColor(red: 0.4f, green: 0.56f, blue: 0.71f, alpha: 1.00f),
						   titleColor: UIColor.Red,
						   descriptionColor: UIColor.Red,
						   titleFont: UIFont.PreferredBody,
						   descriptionFont: UIFont.PreferredSubheadline,
						   descriptionLabelPadding: 0,
						   titleLabelPadding: 0),

		new OnboardingItemInfoObjC(informationImage: UIImage.FromFile("stores.png"),
						   title: "Stores",
						   description: "All dogs are good",
						   pageIcon: UIImage.FromFile("shopping_cart.png"),
						   color: new UIColor(red: 0.4f, green: 0.56f, blue: 0.71f, alpha: 1.00f),
						   titleColor: UIColor.Green,
						   descriptionColor: UIColor.Green,
						   titleFont: UIFont.PreferredBody,
						   descriptionFont: UIFont.PreferredSubheadline,
						   descriptionLabelPadding: 0,
						   titleLabelPadding: 0),

		};

		public nint OnboardingItemsCount => 3;

		public nfloat OnboardinPageItemRadius => 2;

		public nfloat OnboardingPageItemSelectedRadius => 10;

		public bool EnableTapsOnPageControl => true;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//var onboarding = new PaperOnboarding (CGRect.Empty);
			var onboarding = new PaperOnboarding ();
			onboarding.DataSource = this;
			onboarding.Delegate = this;
			onboarding.TranslatesAutoresizingMaskIntoConstraints = false;
			View.AddSubview (onboarding);
			onboarding.LeadingAnchor.ConstraintEqualTo (View.LeadingAnchor).Active = true;
			onboarding.TrailingAnchor.ConstraintEqualTo (View.TrailingAnchor).Active = true;
			onboarding.TopAnchor.ConstraintEqualTo (View.TopAnchor).Active = true;
			onboarding.BottomAnchor.ConstraintEqualTo (View.BottomAnchor).Active = true;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public OnboardingItemInfoObjC OnboardingItemAt (nint index)
		{
			return items[index];
		}

		public UIColor OnboardingPageItemColorAt (nint index)
		{
			return new UIColor[] { UIColor.White, UIColor.Red, UIColor.Green }[index];
		}

		public void OnboardingWillTransitonToIndex (nint index)
		{
		}

		public void OnboardingWillTransitonToLeaving ()
		{
		}

		public void OnboardingDidTransitonToIndex (nint index)
		{
		}

		public void OnboardingConfigurationItem (OnboardingContentViewItem item, nint index)
		{
		}
	}
}