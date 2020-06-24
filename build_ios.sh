#!/bin/sh

set -e

SDK=iphoneos13.5

cd PaperOnboarding.Xamarin.iOS/paper-onboarding/PaperOnboardingDemo
# Step 1. Build Device and Simulator versions
xcodebuild -target PaperOnboarding -scheme PaperOnboarding -sdk iphoneos -derivedDataPath builds ONLY_ACTIVE_ARCH=NO
xcodebuild -target PaperOnboarding -scheme PaperOnboarding -sdk iphonesimulator -derivedDataPath builds ONLY_ACTIVE_ARCH=NO

cp -r builds/Build/Products/Release-iphonesimulator/PaperOnboarding.framework/Modules/PaperOnboarding.swiftmodule/. builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/Modules/PaperOnboarding.swiftmodule/

lipo -create -output PaperOnboarding2 builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/PaperOnboarding builds/Build/Products/Release-iphonesimulator/PaperOnboarding.framework/PaperOnboarding
mv PaperOnboarding2 builds/Build/Products/Release-iphoneos/PaperOnboarding.framework
rm builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/PaperOnboarding
mv builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/PaperOnboarding2 builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/PaperOnboarding
sharpie bind -sdk $SDK -namespace PaperOnboardingXamarin.iOS -scope builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/Headers builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/Headers/PaperOnboarding-Swift.h
cd ../..
cp -r paper-onboarding/PaperOnboardingDemo/builds/Build/Products/Release-iphoneos/PaperOnboarding.framework .
#cp paper-onboarding/PaperOnboardingDemo/ApiDefinitions.cs ApiDefinition.cs
#cp paper-onboarding/PaperOnboardingDemo/StructsAndEnums.cs Structs.cs
#sed -i '' '/Verify/d' ApiDefinition.cs

cd ..
nuget restore
msbuild /t:Rebuild /p:Configuration=Release PaperOnboarding.Xamarin.iOS/PaperOnboarding.Xamarin.iOS.csproj
#msbuild /t:pack /p:Configuration=Release PaperOnboarding.Xamarin.iOS/PaperOnboarding.Xamarin.iOS.csproj

mkdir -p _builds/paper-onboarding
cp PaperOnboarding.Xamarin.iOS/bin/Release/PaperOnboarding.Xamarin.iOS*.dll _builds/paper-onboarding/
cp PaperOnboarding.Xamarin.iOS/bin/Package/PaperOnboarding.Xamarin.iOS.*.nupkg _builds/nugets/PaperOnboarding.Xamarin.iOS.nupkg
cp PaperOnboarding.Xamarin.iOS/obj/Release/*.nuspec _builds/nugets
