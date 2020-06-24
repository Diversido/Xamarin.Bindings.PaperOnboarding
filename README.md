# Xamarin.Bindings.PaperOnboarding
This is Xamarin bindings for paper-onboarding library made by Ramotion

IMPORTANT: The sources for the bindings were a bit modified for our companies needs.

You can install them via Nuget:

https://www.nuget.org/packages/paperonboarding.xamarin.iOS/
https://www.nuget.org/packages/paperonboarding.xamarin.android/

How to add changes:

 - ***Android***
 
	Make changes in bindings or directly in the source (*paper-onboarding-android* folder) and just use *build_android.sh* afterwards to get updated .dll and/or Nuget packages in *_builds* folder.
	
 - ***iOS***
 
	 If you gonna change only bindings, proceed to the *build_ios.sh* afterwards to get updated .dll and/or Nuget packages in *_builds* folder.
	 If you had to change source library, you will need to make new ApiDefinitions first with *build_ios_ApiDefinitions.sh*
	 (This will make two builds for both Device and Simulators architectures and then will make the Fat library, but
	 NOTE: while assembling the Fat library some ambiguities can occur that would be marked as "Verify", the script will remove all Verify marks (you can remove the last line to check out the ambiguities yourself))
	 and then run *build_ios.sh*.

# Developer Guide

## NuGet specs

NuGet Package created as part of the Release build process with a help of `NuGet.Build.Tasks.Pack` package.
The usage described here: https://docs.microsoft.com/en-us/nuget/create-packages/creating-a-package-msbuild

Previousely used `NuGet.Build.Packaging` stoppted to work (an error during the build) and has not been updated for 3 years.

DO NOT try to modify NuGet package Metadata from the Visual Studio project settings.
Instead modify the .csproj files.

## Publishing

1. Ensure to update package versions inside `PaperOnboarding.Xamarin.Android.csproj` and `PaperOnboarding.Xamarin.IOS.csproj` files

2. Run

```bash
# build
sh build_android.sh
sh build_ios.sh

# publish
sh nuget_android.sh
sh nuget_ios.sh
```

## Troubleshooting

If the iOS build script fails:

- update `SDK` property to match the locally intalled one 
- ensure the `sharpie` CLI is installed (https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-sharpie/get-started)
