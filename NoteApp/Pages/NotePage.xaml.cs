using NoteApp.Models;
using NoteApp.ViewModels;

namespace NoteApp.Pages;

[QueryProperty(nameof(ID), "id")]
public partial class NotePage : ContentPage
{
    NoteViewModel Notes;
    private NoteModel note;

    private string? titleString;
    private string? descriptionString;

    private Guid _id;
    public Guid ID
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    public NotePage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        // Reset values
        title.Text = null;
        description.Text = null;

        base.OnAppearing();

        Notes = new NoteViewModel();
        note = Notes.GetNote(ID);

        if (note == null) 
        {
            Console.WriteLine("ERROR: note is null for edit page.");
            return;
        }

        if (note.title != null)
            title.Text = note.title;

        if (note.description != null)
            description.Text = note.description;
    }

    private void OnTitleChanged(object sender, TextChangedEventArgs e)
    {
        titleString = title.Text;
    }

    private void OnDescriptionChanged(object sender, TextChangedEventArgs e)
    {
        descriptionString = description.Text;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        if (titleString != note.title || descriptionString != note.description)
        {
            Notes.EditNote(ID, titleString, descriptionString);
        }

        await Shell.Current.GoToAsync("//main", true);
    }
}