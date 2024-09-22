namespace Pro02.Views;

public partial class NewsPage : ContentPage
{
	public NewsPage()
	{
		InitializeComponent();
	}

    async void Regis_Clicked(object sender, EventArgs e)
    {
        bool isRegis = await DisplayAlert("Register?", "ต้องการลงทะเบียนผู้ใช้งานใหม่", "ตกลง", "ไม่ใช่");

        if (isRegis)
        {
            await DisplayAlert("Register", "ลงทะเบียนผู้ใช้งานใหม่", "ตกลง");
            App.Current.MainPage = new Views.LoginPage();
        }
    }

    public void Back_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Views.LoginPage();
    }
}