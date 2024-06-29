using Spectre.Console;

namespace LibraryTerminalLab;

public static class Catalog
{

    private static List<Book> BookList = new List<Book>
        {
            new Book("1984", "George Orwell",BookStatus.OnShelf, "Dystopian Fiction"),
            new Book("To Kill a Mockingbird", "Harper Lee",BookStatus.OnShelf, "Southern Gothic"),
            new Book("The Great Gatsby", "F. Scott Fitzgerald",BookStatus.OnShelf, "Literary Fiction"),
            new Book("Pride and Prejudice", "Jane Austen",BookStatus.OnShelf, "Romance"),
            new Book("Brave New World", "Aldous Huxley",BookStatus.OnShelf, "Science Fiction"),
            new Book("The Catcher in the Rye", "J.D. Salinger",BookStatus.CheckedOut, "Coming-of-Age Fiction",DateTime.Today.AddDays(14)),
            new Book("Catch-22", "Joseph Heller",BookStatus.OnShelf, "Satire"),
            new Book("Moby-Dick", "Herman Melville",BookStatus.OnShelf, "Adventure Fiction"),
            new Book("War and Peace", "Leo Tolstoy",BookStatus.OnShelf, "Historical Fiction"),
            new Book("The Lord of the Rings", "J.R.R. Tolkien",BookStatus.OnShelf, "Fantasy"),
            new Book("Crime and Punishment", "Fyodor Dostoevsky",BookStatus.CheckedOut, "Psychological Fiction", DateTime.Today.AddDays(14)),
            new Book("Beloved", "Toni Morrison",BookStatus.OnShelf, "Historical Fiction"),
            new Book("Slaughterhouse-Five", "Kurt Vonnegut",BookStatus.OnShelf, "Science Fiction"),
            new Book("The Road", "Cormac McCarthy",BookStatus.OnShelf, "Post-Apocalyptic Fiction"),
            new Book("One Hundred Years of Solitude","Gabriel Garcia Marquez",BookStatus.OnShelf,"Magical Realism")
        };

    public static List<Book> SearchBooks()
    {
        List<Book> results = [];

        while (true)
        {
            try
            {
                Console.WriteLine("What book are you looking for? (Title/Author/Genre)");
                string userInput = Console.ReadLine();

                foreach (Book book in BookList)
                {
                    //hate how this looks, want to refactor to simplify
                    if (book.Title.Contains(userInput, StringComparison.InvariantCultureIgnoreCase) ||
                        book.Author.Contains(userInput, StringComparison.InvariantCultureIgnoreCase) ||
                        book.Genre.Contains(userInput, StringComparison.InvariantCultureIgnoreCase))
                    {
                        results.Add(book);
                    }
                }

                if (results.Count > 0)
                    return results;

                Console.WriteLine("No matching results found, please saerch again.");
            }
            catch
            {
                Console.WriteLine("Error reading your input, please try again");
            }

        }


    }
    public static List<Book> ListAllBooks() 
    { 
        return BookList; 
    }
    public static List<Book> ListCheckedOut()
    {
        return BookList.Where(x => x.Status == BookStatus.CheckedOut).ToList();
    }

    public static Book SelectABook(List<Book> books)
    {
        Table table = new Table().Centered();

        table.Title("Available Books");


        AnsiConsole.Live(table).Start(screen =>
        {
            table.AddColumn("Menu Option");
            screen.Refresh();
            Thread.Sleep(100);
            table.AddColumn("Title");
            screen.Refresh();
            Thread.Sleep(100);
            table.AddColumn("Author");
            screen.Refresh();
            Thread.Sleep(100);
            table.AddColumn("Book Status");
            screen.Refresh();
            Thread.Sleep(100);
            table.AddColumn("Book Genre");
            screen.Refresh();
            Thread.Sleep(100);

            for (int i = 0; i < books.Count(); i++)
            {
                table.AddRow((i + 1).ToString(), books[i].Title, books[i].Author, books[i].Status.ToString(), books[i].Genre);
                screen.Refresh();
                Thread.Sleep(100);
            }
        });

        Console.WriteLine("Please make a selection");

        int selectedIndex = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the index of the book you want to select:")
            .Validate(index => index - 1 >= 0 && index - 1 < books.Count ?
            ValidationResult.Success() : ValidationResult.Error("Invalid index")
            )) - 1;

        var selectedBook = books[selectedIndex];

        return selectedBook;
    }
}
