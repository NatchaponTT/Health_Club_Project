namespace Pro02.Views;

public partial class BMIPage : ContentPage
{
	const double UnderweightThreshole = 18.5;
    const double NomalweightThreshole = 24.9;
    const double OverweightThreshole = 29.9;

    public BMIPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var weight = double.Parse(Weight.Text);
		var height = double.Parse(Height.Text)/100;

		var imc = weight / (height * height);

		BMI.Text = imc.ToString("F2");

		string result = GetBmiResultMessage(imc);
		DisplayAlert("Result", result, "OK");
    }
	private string GetBmiResultMessage(double imc)
	{
		if (imc < UnderweightThreshole)
		{
			return "You Have low weight";
		}
		else if (imc <= NomalweightThreshole)
		{
			return "You Weight is Nomal";
        }
		else if(imc <= OverweightThreshole)
		{
			return "You is Overweight";
        }
		else
		{
			return "You have obesity, take cae of yourself!";
        }
		
	}

    private void Button_Clicked_1(object sender, EventArgs e)
    {
		App.Current.MainPage = new Views.ProfilePage();

    }
}