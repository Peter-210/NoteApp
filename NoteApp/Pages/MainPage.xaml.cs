using Microsoft.Maui.Controls;
using NoteApp.ViewModels;

namespace NoteApp.Pages;

public partial class MainPage : ContentPage
{
	public NoteViewModel NoteViewModel { get; private set; }

	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

        NoteViewModel = new NoteViewModel();
		BindingContext = NoteViewModel;

        noteList.BindingContext = NoteViewModel;
        newNoteButton.BindingContext = NoteViewModel;
    }
}