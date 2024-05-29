using System.Collections.ObjectModel;
using NoteApp.Models;
using NoteApp.ViewModels;

namespace NoteApp.Controls;

public partial class NoteList : ContentView
{
	public NoteList()
	{
		InitializeComponent();
    }

    private async void OnEditNoteClicked(object sender, EventArgs e)
    {
        var id = ((TappedEventArgs)e).Parameter;

		if (id == null)
		{
			Console.WriteLine("ERROR: ID is null during pass to NotePage.xaml");
			return;
		}

		await Shell.Current.GoToAsync(
			"//note",true,new Dictionary<string, object>() { { "id", id } }
		);
    }

	private async void OnDeleteNoteClicked(object sender, EventArgs e)
	{
        var id = ((TappedEventArgs)e).Parameter;

        if (id == null)
        {
            Console.WriteLine("ERROR: ID is null during pass to NotePage.xaml");
            return;
        }

        ObservableCollection<NoteViewModel> noteList = 
            (ObservableCollection<NoteViewModel>)noteCollectionView.ItemsSource;

        //object value = noteList.DeleteNote(id);
    }
}