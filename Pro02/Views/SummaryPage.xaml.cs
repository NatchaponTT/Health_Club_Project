namespace Pro02.Views;

public partial class SummaryPage : ContentPage
{
	public SummaryPage()
	{
		InitializeComponent();
	}

    async void Button_Clicked(object sender, EventArgs e)
    {
        bool isOut = await DisplayAlert("Logout?", "ต้องการจะออกจากระบบ?", "ตกลง", "ไม่ใช่");

        if (isOut)
        {
            App.Current.MainPage = new Views.LoginPage();
        }
    }
}