namespace NoteApp.Controls;

public partial class NewNoteButton : ContentView
{
	public NewNoteButton()
	{
		InitializeComponent();
	}

	private async void OnNewButtonClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//note", true);
    }
}