using NoteApp.ViewModels;

namespace NoteApp.Pages;

[QueryProperty(nameof(Date), "date")]
public partial class NotePage : ContentPage
{ 
    private string? titleString;
    private string? descriptionString;

    private DateTime _dateData;
    public DateTime Date
    {
        get => _dateData;
        set
        {
            _dateData = value;
            OnPropertyChanged();
        }
    }

    public NotePage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        title.Text = null;
        description.Text = null;
        base.OnAppearing();
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
        await Shell.Current.GoToAsync("//main", true);
    }
}