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
    public string SelectABook(string keyword)
    {

        BookList.Contains(keyword).ToLower().ToList();


    }

    public string ReturnBook(string returnBook)
    {
        foreach (string b in BookList)
        {
            if (b.Title.Contains(returnBook) || (b.Author.Contains(returnBook) || (b.Genre.Contains(returnBook))
            {

                BookList.Add(returnBook(b));
            }
        }


    }


}
}