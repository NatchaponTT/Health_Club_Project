using Microsoft.VisualBasic;
using Pro02.Models;
namespace Pro02.Views;

public partial class NoteEnterPage : ContentPage
{
	public NoteEnterPage()
	{
		InitializeComponent();
	}

    async void btnSave_Clicked(object sender, EventArgs e)
    {
        var note = (Note)BindingContext;

        if (string.IsNullOrWhiteSpace(note.FileName))
        {
            // Save new note
            var filename = Path.Combine(
                App.FolderPath,
                $"{DateAndTime.Now.ToString("yyyyMMddHHmmss")}.notes.txt");
            File.WriteAllText(filename, $"#{note.Text}");
        }
        else
        {
            // Update Note
            File.WriteAllText(note.FileName, $"{note.Text}#,#{note.Text}");
        }
        await Navigation.PopAsync();
    }


    async void btnDelete_Clicked(object sender, EventArgs e)
    {
        var note = (Note)BindingContext;
        if (File.Exists(note.FileName))
        {
            File.Delete(note.FileName);
        }
        await Navigation.PopAsync();
    }
}