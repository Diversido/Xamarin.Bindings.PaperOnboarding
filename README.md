# Xamarin.Bindings.PaperOnboarding
This is Xamarin bindings for paper-onboarding library made by Ramotion

IMPORTANT: The sources for the bindings were a bit modified for our companies needs.

You can install them via Nuget:

https://www.nuget.org/packages/paperonboarding.xamarin.iOS/
https://www.nuget.org/packages/MaterialShowcase.Xamarin.Android/

How to add changes:

 - ***Android***
 
	Make changes in bindings or directly in the source (*paper-onboarding-android* folder) and just use *build_android.sh* afterwards to get updated .dll and/or Nuget packages in *_builds* folder.
	
 - ***iOS***
 
	 If you gonna change only bindings, proceed to the *build_ios.sh* afterwards to get updated .dll and/or Nuget packages in *_builds* folder.
	 If you had to change source library, you will need to make new ApiDefinitions first with *build_ios_ApiDefinitions.sh*
	 (This will make two builds for both Device and Simulators architectures and then will make the Fat library, but
	 NOTE: while assembling the Fat library some ambiguities can occur that would be marked as "Verify", the script will remove all Verify marks (you can remove the last line to check out the ambiguities yourself))
	 and then run *build_ios.sh*.
