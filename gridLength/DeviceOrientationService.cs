namespace gridLength;

public enum DeviceOrientation
{
    Undefined,
    Landscape,
    Portrait
}

public partial class DeviceOrientationService
{
    #region Instance

    private static DeviceOrientationService _Instance = null;
    public static DeviceOrientationService Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new DeviceOrientationService();
            return _Instance;
        }
    }

    #endregion

    public partial DeviceOrientation GetOrientation();

    public partial void SetOrientation(DeviceOrientation orientation);
}