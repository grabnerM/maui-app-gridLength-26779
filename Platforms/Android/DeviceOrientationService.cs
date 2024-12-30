using Android.Content.PM;

namespace gridLength;

public partial class DeviceOrientationService
{
    public partial DeviceOrientation GetOrientation()
	{
		ScreenOrientation source = Platform.CurrentActivity.RequestedOrientation;

		switch (source)
		{
			case ScreenOrientation.Portrait:
				return DeviceOrientation.Portrait;
			case ScreenOrientation.SensorLandscape:
				return DeviceOrientation.Landscape;
			default:
				return DeviceOrientation.Undefined;
		}
	}

	public partial void SetOrientation(DeviceOrientation orientationLock)
	{
		ScreenOrientation target;

		switch (orientationLock)
		{
			case DeviceOrientation.Portrait:
				target = ScreenOrientation.Portrait;
				break;
			case DeviceOrientation.Landscape:
				target = ScreenOrientation.SensorLandscape;
				break;
			default:
				target = ScreenOrientation.Unspecified;
				break;
		}

		Platform.CurrentActivity.RequestedOrientation = target;
	}
}