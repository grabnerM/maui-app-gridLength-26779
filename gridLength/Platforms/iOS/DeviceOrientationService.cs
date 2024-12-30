using Foundation;
using UIKit;

namespace gridLength;

public partial class DeviceOrientationService
{
    public partial DeviceOrientation GetOrientation()
    {
        NSNumber orientation = UIDevice.CurrentDevice?.ValueForKey(new NSString("orientation")) as NSNumber;
        if (orientation == null)
            return DeviceOrientation.Undefined;

        switch (orientation.Int32Value)
        {
            case (int)UIInterfaceOrientation.Portrait:
            case (int)UIInterfaceOrientation.PortraitUpsideDown:
                return DeviceOrientation.Portrait;
            case (int)UIInterfaceOrientation.LandscapeLeft:
                return DeviceOrientation.Landscape;
            case (int)UIInterfaceOrientation.LandscapeRight:
                return DeviceOrientation.Landscape;
            case 5: // faceUp: The device is held parallel to the ground with the screen facing upwards.
            case 6: // faceDown: The device is held parallel to the ground with the screen facing downwards. 
                return DeviceOrientation.Landscape;
            default:
                return DeviceOrientation.Undefined;
        }
    }
    
    public partial void SetOrientation(DeviceOrientation orientationLock)
    {
        UIInterfaceOrientation target;
        UIInterfaceOrientationMask mask;

        switch (orientationLock)
        {
            case DeviceOrientation.Portrait:
                target = UIInterfaceOrientation.Portrait;
                mask = UIInterfaceOrientationMask.Portrait;
                break;
            case DeviceOrientation.Landscape:
                target = UIInterfaceOrientation.LandscapeRight;
                mask = UIInterfaceOrientationMask.LandscapeLeft | UIInterfaceOrientationMask.LandscapeRight;
                break;
            default:
                target = UIInterfaceOrientation.Unknown;
                mask = UIInterfaceOrientationMask.All;
                break;
        }

        if (UIDevice.CurrentDevice.CheckSystemVersion(16, 0))
        {
            UIScene[] connectedScenes = UIApplication.SharedApplication?.ConnectedScenes?.ToArray() ?? new UIScene[0];
            UIWindowScene windowScene = connectedScenes.Length > 0 ? connectedScenes[0] as UIWindowScene : null;
            UIViewController rootViewController = UIApplication.SharedApplication?.KeyWindow?.RootViewController;
            if (windowScene != null && rootViewController != null)
            {
                // Tell the OS that we changed orientations so it knows to call GetSupportedInterfaceOrientations again
                rootViewController.SetNeedsUpdateOfSupportedInterfaceOrientations();
                windowScene.RequestGeometryUpdate(new UIWindowSceneGeometryPreferencesIOS(mask), error => { });
            }
        }
        else
        {
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)target), new NSString("orientation"));
        }
    }
}