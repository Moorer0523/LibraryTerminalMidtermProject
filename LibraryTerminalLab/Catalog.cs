using static System.Collections.Specialized.BitVector32;

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
            new Book("The Catcher in the Rye", "J.D. Salinger",BookStatus.OnShelf, "Coming-of-Age Fiction"),
            new Book("Catch-22", "Joseph Heller",BookStatus.OnShelf, "Satire"),
            new Book("Moby-Dick", "Herman Melville",BookStatus.OnShelf, "Adventure Fiction"),
            new Book("War and Peace", "Leo Tolstoy",BookStatus.OnShelf, "Historical Fiction"),
            new Book("The Lord of the Rings", "J.R.R. Tolkien",BookStatus.OnShelf, "Fantasy"),
            new Book("Crime and Punishment", "Fyodor Dostoevsky",BookStatus.OnShelf, "Psychological Fiction"),
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

                BookList.Where(book =>
                book.Title.Contains(userInput, StringComparison.InvariantCultureIgnoreCase) ||
                book.Author.Contains(userInput, StringComparison.InvariantCultureIgnoreCase) ||
                book.Genre.Contains(userInput, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

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

    public static List<Book> SelectABook(Book book)
    {
        
        
        while (true)
        {
            Console.WriteLine("Please select a number.");
            int selection = int.Parse(Console.ReadLine());

            if (selection > 0 && selection < 15)
            {
                return B
            }
            else (selection < 0 && selection > 15)
        }
                    

        
       
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
            Console.WriteLine($"Book '{book.Title}' returned successfully.");
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is not currently checked out.");
        }
    }

}
