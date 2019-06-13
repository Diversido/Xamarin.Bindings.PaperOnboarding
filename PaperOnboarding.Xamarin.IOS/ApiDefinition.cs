using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace PaperOnboardingXamarin.iOS
{
	// @interface GestureControl : UIView
	[BaseType (typeof(UIView))]
	interface GestureControl
	{
	}

	// @interface OnboardingContentViewItem : UIView
	[BaseType (typeof(UIView))]
	interface OnboardingContentViewItem
	{
		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)_ __attribute__((objc_designated_initializer));
		//[Export ("initWithCoder:")]
		//[DesignatedInitializer]
		//IntPtr Constructor (NSCoder _);
	}

	// @interface OnboardingItemInfoObjC : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OnboardingItemInfoObjC
	{
		// -(instancetype _Nonnull)initWithInformationImage:(UIImage * _Nonnull)informationImage title:(NSString * _Nonnull)title description:(NSString * _Nonnull)description pageIcon:(UIImage * _Nonnull)pageIcon color:(UIColor * _Nonnull)color titleColor:(UIColor * _Nonnull)titleColor descriptionColor:(UIColor * _Nonnull)descriptionColor titleFont:(UIFont * _Nonnull)titleFont descriptionFont:(UIFont * _Nonnull)descriptionFont descriptionLabelPadding:(CGFloat)descriptionLabelPadding titleLabelPadding:(CGFloat)titleLabelPadding __attribute__((objc_designated_initializer));
		[Export ("initWithInformationImage:title:description:pageIcon:color:titleColor:descriptionColor:titleFont:descriptionFont:descriptionLabelPadding:titleLabelPadding:")]
		[DesignatedInitializer]
		IntPtr Constructor (UIImage informationImage, string title, string description, UIImage pageIcon, UIColor color, UIColor titleColor, UIColor descriptionColor, UIFont titleFont, UIFont descriptionFont, nfloat descriptionLabelPadding, nfloat titleLabelPadding);
	}

	// @interface PaperOnboarding : UIView
	[BaseType (typeof(UIView))]
	interface PaperOnboarding
	{
		// @property (nonatomic, weak) id _Nullable dataSource __attribute__((iboutlet));
		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		NSObject DataSource { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		NSObject Delegate { get; set; }

		// @property (nonatomic, weak) id _Nullable delegate __attribute__((iboutlet));
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nonnull)initWithPageViewBottomConstant:(CGFloat)pageViewBottomConstant __attribute__((objc_designated_initializer));
		[Export ("initWithPageViewBottomConstant:")]
		[DesignatedInitializer]
		IntPtr Constructor (nfloat pageViewBottomConstant);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		//[Export ("initWithCoder:")]
		//[DesignatedInitializer]
		//IntPtr Constructor (NSCoder aDecoder);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frame);
	}

	// @protocol PaperOnboardingDataSource
	[Protocol, Model]
	interface PaperOnboardingDataSource
	{
		// @required -(NSInteger)onboardingItemsCount __attribute__((warn_unused_result));
		[Abstract]
		[Export ("onboardingItemsCount")]
		nint OnboardingItemsCount { get; }

		// @required -(OnboardingItemInfoObjC * _Nonnull)onboardingItemAt:(NSInteger)index __attribute__((warn_unused_result));
		[Abstract]
		[Export ("onboardingItemAt:")]
		OnboardingItemInfoObjC OnboardingItemAt (nint index);

		// @required -(UIColor * _Nonnull)onboardingPageItemColorAt:(NSInteger)index __attribute__((warn_unused_result));
		[Abstract]
		[Export ("onboardingPageItemColorAt:")]
		UIColor OnboardingPageItemColorAt (nint index);

		// @required -(CGFloat)onboardinPageItemRadius __attribute__((warn_unused_result));
		[Abstract]
		[Export ("onboardinPageItemRadius")]
		nfloat OnboardinPageItemRadius { get; }

		// @required -(CGFloat)onboardingPageItemSelectedRadius __attribute__((warn_unused_result));
		[Abstract]
		[Export ("onboardingPageItemSelectedRadius")]
		nfloat OnboardingPageItemSelectedRadius { get; }
	}

	// @protocol PaperOnboardingDelegate
	[Protocol, Model]
	interface PaperOnboardingDelegate
	{
		// @required -(void)onboardingWillTransitonToIndex:(NSInteger)index;
		[Abstract]
		[Export ("onboardingWillTransitonToIndex:")]
		void OnboardingWillTransitonToIndex (nint index);

		// @required -(void)onboardingWillTransitonToLeaving;
		[Abstract]
		[Export ("onboardingWillTransitonToLeaving")]
		void OnboardingWillTransitonToLeaving ();

		// @required -(void)onboardingDidTransitonToIndex:(NSInteger)index;
		[Abstract]
		[Export ("onboardingDidTransitonToIndex:")]
		void OnboardingDidTransitonToIndex (nint index);

		// @required -(void)onboardingConfigurationItem:(OnboardingContentViewItem * _Nonnull)item index:(NSInteger)index;
		[Abstract]
		[Export ("onboardingConfigurationItem:index:")]
		void OnboardingConfigurationItem (OnboardingContentViewItem item, nint index);

		// @required @property (readonly, nonatomic) BOOL enableTapsOnPageControl;
		[Abstract]
		[Export ("enableTapsOnPageControl")]
		bool EnableTapsOnPageControl { get; }
	}
}
