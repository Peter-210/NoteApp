using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using NoteApp.Models;

namespace NoteApp.ViewModels;

public class NoteViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private ObservableCollection<NoteModel>? _noteCollection;
    public ObservableCollection<NoteModel>? NoteCollection
    {
        get => _noteCollection;
        set
        {
            if (_noteCollection != value)
            {
                _noteCollection = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand AddNoteCommand => new Command(AddNote);

    private void AddNote()
    {
        NoteCollection?.Add(new NoteModel
        {
            title = "Test",
            description = "Work",
            date = DateTime.Now
        });
    }

    public NoteViewModel()
    {
        initNoteList();
    }

    private void initNoteList() 
    {
        NoteCollection = new ObservableCollection<NoteModel>();

        //AddNoteEvent("My Title", "Lorem ipon", new DateTime(2021, 1, 1));
        //AddNoteEvent("My Title", "Lorem ipon", new DateTime(2022, 2, 2));
        //AddNoteEvent("My Title", "Lorem ipon", new DateTime(2023, 3, 3));
    }

    public void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }       
}