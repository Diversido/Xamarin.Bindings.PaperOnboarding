cd PaperOnboarding.Xamarin.iOS/paper-onboarding/PaperOnboardingDemo
# Step 1. Build Device and Simulator versions
xcodebuild -target PaperOnboarding -scheme PaperOnboarding -sdk iphoneos -derivedDataPath builds -configuration Release build
xcodebuild -target PaperOnboarding -scheme PaperOnboarding -sdk iphonesimulator -derivedDataPath builds -configuration Release build

cp -r builds/Build/Products/Release-iphonesimulator/PaperOnboarding.framework/Modules/PaperOnboarding.swiftmodule/. builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/Modules/PaperOnboarding.swiftmodule/

lipo -create -output PaperOnboarding2 builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/PaperOnboarding builds/Build/Products/Release-iphonesimulator/PaperOnboarding.framework/PaperOnboarding
mv PaperOnboarding2 builds/Build/Products/Release-iphoneos/PaperOnboarding.framework
rm builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/PaperOnboarding
mv builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/PaperOnboarding2 builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/PaperOnboarding
sharpie bind -sdk iphoneos12.2 -namespace PaperOnboardingXamarin.iOS -scope builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/Headers builds/Build/Products/Release-iphoneos/PaperOnboarding.framework/Headers/PaperOnboarding-Swift.h
cd ../..
cp -r paper-onboarding/PaperOnboardingDemo/builds/Build/Products/Release-iphoneos/PaperOnboarding.framework .
cp paper-onboarding/PaperOnboardingDemo/ApiDefinitions.cs ApiDefinition.cs
cp paper-onboarding/PaperOnboardingDemo/StructsAndEnums.cs Structs.cs
sed -i '' '/Verify/d' ApiDefinition.cs