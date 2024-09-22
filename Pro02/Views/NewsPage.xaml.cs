namespace Pro02.Views;

public partial class NewsPage : ContentPage
{
	public NewsPage()
	{
		InitializeComponent();
	}

    async void Regis_Clicked(object sender, EventArgs e)
    {
        bool isRegis = await DisplayAlert("Register?", "��ͧ���ŧ����¹�����ҹ����", "��ŧ", "�����");

        if (isRegis)
        {
            await DisplayAlert("Register", "ŧ����¹�����ҹ����", "��ŧ");
            App.Current.MainPage = new Views.LoginPage();
        }
    }

    public void Back_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Views.LoginPage();
    }
}