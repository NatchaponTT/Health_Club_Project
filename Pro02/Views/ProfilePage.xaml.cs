namespace Pro02.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Views.NotePage();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        App.Current.MainPage = new Views.BMIPage();
    }
}