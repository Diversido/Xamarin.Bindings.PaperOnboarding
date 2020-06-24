#!/bin/sh

set -e

# build Android library
cd PaperOnboarding.Xamarin.Android/paper-onboarding-android
gradle assembleRelease
cd ../..

# copy libraries to the Xamarin project
cp PaperOnboarding.Xamarin.Android/paper-onboarding-android/paper-onboarding/build/outputs/aar/paper-onboarding-release.aar PaperOnboarding.Xamarin.Android/Jars/paper-onboarding-release.aar

# build Xamarin Bindings
nuget restore
msbuild /t:Rebuild /p:Configuration=Release PaperOnboarding.Xamarin.Android/PaperOnboarding.Xamarin.Android.csproj

mkdir -p _builds/paper-onboarding
mkdir -p _builds/nugets
cp PaperOnboarding.Xamarin.Android/bin/Release/PaperOnboarding.Xamarin.Android*.dll _builds/paper-onboarding/
cp PaperOnboarding.Xamarin.Android/bin/Package/PaperOnboarding.Xamarin.Android.*.nupkg _builds/nugets/PaperOnboarding.Xamarin.Android.nupkg
cp PaperOnboarding.Xamarin.Android/obj/Release/*.nuspec _builds/nugets/
