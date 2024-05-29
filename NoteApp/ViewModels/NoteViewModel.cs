using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;
using NoteApp.Models;

namespace NoteApp.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

public class NoteViewModel : ViewModelBase
{
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

    public ICommand AddNoteCommand => new Command(() => {
        var _id = Guid.NewGuid();
        var note = new NoteModel
        {
            title = null,
            description = null,
            date = DateTime.Now,
            id = _id
        };

        saveNote(note, _id);
    });

    public NoteViewModel()
    {
        initNoteList();
    }

    public NoteModel? GetNote(Guid searchNoteId)
    {
        NoteModel? note = NoteCollection.FirstOrDefault(model => model.id == searchNoteId);
        if (note == null)
        {
            Console.WriteLine("ERROR: note is null");
            return null;
        }
        else
            return note;
    }

    public void EditNote(Guid _id, string _title, string _description)
    {
        NoteModel note = loadNoteFromFile(_id);

        note.title = _title;
        note.description = _description;
        note.date = DateTime.Now;

        //DeleteNote(_id);
        saveNote(note, _id);
    }

    public ICommand DeleteNoteCommand => new Command<Guid>(DeleteNote);

    public void DeleteNote(Guid _id)
    {
        try 
        {
            NoteModel note = GetNote(_id);

            if (note != null)
                NoteCollection.Remove(note);

            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileName = _id.ToString() + "_note.json";
            string filePath = Path.Combine(directoryPath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        } 
        catch (Exception ex)
        {
            Console.WriteLine("ERROR Unable to delete note: " + ex.Message);
        }
        
    }

    private void initNoteList()
    {
        NoteCollection = new ObservableCollection<NoteModel>();

        try
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string[] noteJsonFiles = Directory.GetFiles(directoryPath, "*_note.json");

            foreach (string jsonFile in noteJsonFiles)
            {
                string json = File.ReadAllText(jsonFile);

                NoteModel? note = JsonSerializer.Deserialize<NoteModel>(json);
                NoteCollection?.Add(note);
            }
                
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR loading note data of JSON files: " + ex.Message);
        }
    }

    private void saveNote(NoteModel note, Guid noteID)
    {
        string json = JsonSerializer.Serialize(note);
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), noteID.ToString() + "_note.json");

        Console.WriteLine(filePath);

        File.WriteAllText(filePath, json);
        NoteCollection?.Add(note);
    }

    private NoteModel loadNoteFromFile(Guid noteID)
    {
        string filePath = noteID.ToString() + "_note.json";
        string json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<NoteModel>(json);
    }
}