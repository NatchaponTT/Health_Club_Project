using System.Windows.Input;

namespace Pro02
{
    public partial class AppShell : Shell
    {
        public ICommand HelpCommand { get; set; }
        public ICommand AboutCommand { get; set; }

        public AppShell()
        {
            InitializeComponent();
            HelpCommand = new Command<string>(ActionCommand);
            AboutCommand = new Command<string>(ActionCommand);
            this.BindingContext = this;
        }
        public async void ActionCommand(string pUrl)
        {
            await Launcher.Default.OpenAsync(pUrl);
        }
    }
}
