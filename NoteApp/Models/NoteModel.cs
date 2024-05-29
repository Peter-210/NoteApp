namespace NoteApp.Models;

public class NoteModel
{
    public string? title { get; set; }
    public string? description { get; set; }
    public DateTime date { get; set; }
    public Guid id { get; set; }
}