namespace Pro02.Views;

public partial class SummaryPage : ContentPage
{
	public SummaryPage()
	{
		InitializeComponent();
	}

    async void Button_Clicked(object sender, EventArgs e)
    {
        bool isOut = await DisplayAlert("Logout?", "��ͧ��è��͡�ҡ�к�?", "��ŧ", "�����");

        if (isOut)
        {
            App.Current.MainPage = new Views.LoginPage();
        }
    }
}