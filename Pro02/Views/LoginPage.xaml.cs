namespace Pro02.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void btnlogin_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new AppShell();
    }

    async void Button_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Views.NewsPage();
    }
}