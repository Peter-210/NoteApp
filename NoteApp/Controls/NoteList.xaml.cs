namespace NoteApp.Controls;

public partial class NoteList : ContentView
{
	public NoteList()
	{
		InitializeComponent();
    }

    private async void OnEditNoteClicked(object sender, EventArgs e)
    {
        var dateId = ((TappedEventArgs)e).Parameter;

		if (dateId == null)
		{
			Console.WriteLine("ERROR: dateId is null during pass to NotePage.xaml");
			return;
		}

		await Shell.Current.GoToAsync(
			"//note",true,new Dictionary<string, object>() { { "date", dateId } }
		);
    }
}