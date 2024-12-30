namespace gridLength;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Page page = new MainPage();
		NavigationPage navPage = new NavigationPage(page);
		MainPage = navPage;
	}
}
