using LibraryTerminalLab;
using System.Net.NetworkInformation;


Console.WriteLine("Welcome to Library Terminal");
Console.WriteLine("1.Search for a Book to check out:");
Console.WriteLine("2.List All Books:");
Console.WriteLine("3.Return a Book:");
Console.WriteLine("4.Exit:");

while (true)
{
    Console.WriteLine("Please Select a Choice:");
    string userInput = Console.ReadLine();

   switch(userInput)
    {
        case "1":
            List<Book> books = Catalog.SearchBooks();
            //select a book from the list -- gives us a book back. Theoretical Section
            //Book placeholderBook;
            //if (placeholderBook.Status == BookStatus.OnShelf)
            //    Catalog.Checkout();
            //else
            //    Console.WriteLine($"Sorry, this book isn't here: {placeholderBook.DueDate}");
            break;
        case "2":
            Console.WriteLine("Here is a List of All Books:");
            //Theoretical Section
            //Catalog.SelectABook(Catalog.ListAllBooks());
            break;
        case "3":
            Console.WriteLine("What book are you returning?");
            string returnInput = Console.ReadLine();
            //pending merger from method
            //Catalog.ReturnBook();
            break;
        case "4":
            Console.WriteLine("Thank You GoodBye!");
            return;
        default:
            Console.WriteLine("Invalid choice. Please select 1-4.");
            break;

    }
}

