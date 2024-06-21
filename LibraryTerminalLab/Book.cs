using Spectre.Console;

namespace LibraryTerminalLab;

//+ Title:string
//+ Author:string
//+ Status: Enum
//+ DueDate:DateTime
//+ Genre: string

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public BookStatus Status { get; set; }
    public DateTime DueDate { get; set; }
    public string Genre { get; set; }

    public Book(string title, string author, BookStatus status, string genre) //Need to add status when created
    {
        Title = title;
        Author = author;
        Status = status;
        Genre = genre;
    }
}
