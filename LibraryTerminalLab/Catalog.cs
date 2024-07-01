using Newtonsoft.Json;
using Spectre.Console;
using System.Reflection.Metadata.Ecma335;

namespace LibraryTerminalLab;

public static class Catalog
{

    //couldn't make readonly and static, unsure if static is the right way to go with this class
    private static string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\CatalogStorage");
    private static string filePath = Path.Combine(directoryPath, "CurrentCatalog.txt");

    private static List<Book> BookList = new List<Book> { };

    //introduced hardcoded list to make sure something is able to be referenced during program run
    private static List<Book> BackupCatalog = new List<Book>
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

    public static void CheckoutBook(Book book)
    {
        if (book.Status == BookStatus.OnShelf)
        {
            book.Status = BookStatus.CheckedOut;
            book.DueDate = DateTime.Today.AddDays(14);
            Console.WriteLine($"Book '{book.Title}' checked out successfully. Due date is {book.DueDate.ToShortDateString()}.");
        }
        else
        {
            Console.WriteLine($"Sorry, '{book.Title}' is currently {book.Status}. Due date: {book.DueDate.ToShortDateString()}.");
        }
    }

    public static void ReturnBook(Book book)
    {
        if (book.Status == BookStatus.CheckedOut)
        {
            book.Status = BookStatus.OnShelf;
            book.DueDate = DateTime.MinValue;
            Console.WriteLine($"Book '{book.Title}' returned successfully.",Color.Green);
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is not currently checked out.", Color.Blue);
        }
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
                var color = "[green]";
                if (books[i].Status == BookStatus.CheckedOut)
                    color = "[red]";

                table.AddRow($"{color}{(i + 1)}[/]", $"{color}{books[i].Title}[/]", $"{ color}{books[i].Author}[/]", $"{color}{books[i].Status}[/]", $"{color}{books[i].Genre}[/]");
                screen.Refresh();
                Thread.Sleep(100);
            }
        });

        int selectedIndex = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the index of the book you want to select:")
            .Validate(index => index - 1 >= 0 && index - 1 < books.Count ?
            ValidationResult.Success() : ValidationResult.Error("Invalid index")
            )) - 1;

        var selectedBook = books[selectedIndex];

        return selectedBook;
    }
  
    public static void Save()
    {
        try
        {
            //checks for directory folder, creates if doesn't exist.
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var json = JsonConvert.SerializeObject(BookList, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine($"Error occurred with saving the file: {ex.Message}");
        }
    }

    public static bool Load()
    {
        try
        {
            //checks for file existing, loads default hardcoded if not
            if (!File.Exists(filePath))
            {

                BookList = BackupCatalog;
                return true;
            }
            else
            {
                var json = File.ReadAllText(filePath);
                BookList = JsonConvert.DeserializeObject<List<Book>>(json);
                return false;
            }

        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine($"Error occurred with loading the file: {ex.Message}");
            BookList = BackupCatalog;
            return false;
        }

    }

    public static void CheckoutOrReturn(Book book)
    {
        var currentStatus = "checked out";
        var currentAction = "return it?";
        if (book.Status == BookStatus.OnShelf)
        {
            currentStatus = "available";
            currentAction = "check it out";
        }

        var userSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"{book.Title} is currently {currentStatus}, would you like to {currentAction}?")
                .PageSize(10)
                .AddChoices("Yes", "No"));
        if (userSelection == "Yes")
        {
            if (book.Status == BookStatus.OnShelf)
                CheckoutBook(book);

            else
                ReturnBook(book);
            Thread.Sleep(1000);
        }
        AnsiConsole.WriteLine($"Returning to the main menu.");
    }
}
