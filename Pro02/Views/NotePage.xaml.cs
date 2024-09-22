using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Pro02.Views;

public partial class NotePage : ContentPage
{
    ObservableCollection<Models.Note> Notes { get; set; }
    public NotePage()
	{
        InitializeComponent();
        Notes = new ObservableCollection<Models.Note>();
        listViewNote.ItemsSource = Notes;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Notes.Clear();

        var files = Directory.EnumerateFiles(App.FolderPath,
            "*.notes.txt");

        files = files.OrderByDescending(x => x);

        string[] arrText = null;
        foreach (var filename in files)
        {
            if (arrText.Count() == 1)
            {
                Notes.Add(new Models.Note
                {
                    FileName = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }
            else if (arrText.Count() > 1)
            {
                Notes.Add(new Models.Note
                {
                    FileName = filename,
                    Text = arrText[1],
                    Date = File.GetCreationTime(filename),
                });
            }
        }
    }

    async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.NoteEnterPage
        {
            BindingContext = new Models.Note()
        });
    }

    async void listViewNote_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection[0] != null)
        {
            Models.Note note = e.CurrentSelection[0] as Models.Note;
            await Navigation.PushAsync(new Views.NoteEnterPage
            {
                BindingContext = note
            });
        }
    }
}