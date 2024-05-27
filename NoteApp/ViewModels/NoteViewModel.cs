using NoteApp.Models;
using System.Windows.Input;

namespace NoteApp.ViewModels;

public class NoteViewModel : ViewModelBase
{ 
    private List<NoteModel> noteCollection;
    public List<NoteModel> NoteCollection
    {
        get => noteCollection;
        set
        {
            if (noteCollection != value)
            {
                noteCollection = value;
                OnPropertyChanged(nameof(noteCollection));
            }
        }
    }

    //public ICommand AddNote { private set; get; }
    //public ICommand EditNote { private set; get; }
    //public ICommand DeleteNote { private set; get; }

    public NoteViewModel()
    {
        noteCollection = new List<NoteModel>();
        initNoteList();

        /*AddNote = new Command<string>(
            execute: (string args) =>
            {
                noteCollection.Add(new NoteModel
                {
                    title = "Test",
                    description = "Work",
                    date = DateTime.Now
                });
            },
            canExecute: (string args) =>
            {
                return true;
            }
        );*/

        /*EditNote = new Command<DateTime>(
            execute: (DateTime time) =>
            {
                noteCollection.Add(new NoteModel
                {
                    title = "Test",
                    description = "Work",
                    date = DateTime.Now
                });
            },
            canExecute: (DateTime time) =>
            {
                // If the note id exists
                return true;
            }
        );*/

        /*DeleteNote = new Command<DateTime>(
            execute: (DateTime time) =>
            {
                noteCollection.Add(new NoteModel
                {
                    title = "Test",
                    description = "Work",
                    date = DateTime.Now
                });
            },
            canExecute: (DateTime time) =>
            {
                // If the note id exists
                return true;
            }
        );*/
    }

    private void initNoteList() 
    {
        AddNoteEvent("My Title", "Lorem ipon", new DateTime(2021, 1, 1));
        AddNoteEvent("My Title", "Lorem ipon", new DateTime(2022, 2, 2));
        AddNoteEvent("My Title", "Lorem ipon", new DateTime(2023, 3, 3));
    }

    private void AddNoteEvent(string _title, string _description, DateTime _date) 
    {
        noteCollection.Add(new NoteModel
        {
            title = _title,
            description = _description,
            date = _date
        });
    }
}