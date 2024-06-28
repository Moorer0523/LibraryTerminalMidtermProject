using LibraryTerminalLab;
using Spectre.Console;
using System.Net.NetworkInformation;



string[] menuOptions = [
   "1.Search for a Book to check out:",
        "2.List All Books:",
        "3.Return a Book:",
        "4.Exit:"
   ];

while (true)
{


    var userSelection = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Welcome to Library Terminal")
        .PageSize(10)
        .AddChoices(menuOptions)
    );

    int userSwitch = Array.FindIndex(menuOptions, x => x == userSelection);

    switch (userSwitch + 1)
    {
        case 1:
            List<Book> books = Catalog.SearchBooks();
            //select a book from the list -- gives us a book back. Theoretical Section
            //Book placeholderBook;
            //if (placeholderBook.Status == BookStatus.OnShelf)
            //    Catalog.Checkout();
            //else
            //    Console.WriteLine($"Sorry, this book isn't here: {placeholderBook.DueDate}");
            break;
        case 2:
            Console.WriteLine("Here is a List of All Books:");
            //Theoretical Section
            //Catalog.SelectABook(Catalog.ListAllBooks());
            break;
        case 3:
            Console.WriteLine("What book are you returning?");
            string returnInput = Console.ReadLine();
            //pending merger from method
            //Catalog.ReturnBook();
            break;
        case 4:
            Console.WriteLine("Thank You GoodBye!");
            return;
        default:
            Console.WriteLine("Invalid choice. Please select 1-4.");
            break;

    }
}

