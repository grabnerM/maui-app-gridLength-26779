using Mopups.Pages;
using Mopups.Services;

namespace gridLength;

public partial class ImagePopup : PopupPage
{
	public ImagePopup() : base()
	{
		InitializeComponent();
	}

	public async void Close(object sender, EventArgs e)
	{
		try
		{
			DeviceOrientationService.Instance.SetOrientation(DeviceOrientation.Portrait);
			await MopupService.Instance.PopAsync();
			await Task.Delay(400); // lock it longer for extra double execution prevention
		}
		catch (Exception ex)
		{
		}
	}
}