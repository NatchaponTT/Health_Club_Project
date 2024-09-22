namespace Pro02;

using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

    public partial class App : Application
    {
        public static string FolderPath { get; set; }
        public App()
        {
            InitializeComponent();

        App.FolderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            MainPage = new Views.LoginPage();
        }
    }

