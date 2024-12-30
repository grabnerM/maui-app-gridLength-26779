using Mopups.Services;

namespace gridLength;

public partial class InnerView : ContentView
{
	int count = 0;

	public InnerView()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private async void OnOpenImage(object sender, EventArgs e)
	{
		DeviceOrientationService.Instance.SetOrientation(DeviceOrientation.Landscape);
		await MopupService.Instance.PushAsync(new ImagePopup());
	}
}