using LibraryTerminalLab;
using Spectre.Console;
using System.Net.NetworkInformation;



string[] menuOptions = [
    "Search for a Book to check out:",
    "List All Books:",
    "Return a Book:",
    "Exit:"
   ];

Catalog.Load();

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
        case 1: //Search for a book and check it out
            List<Book> books = Catalog.SearchBooks();
            //select a book from the list -- gives us a book back. Theoretical Section
            Book selectedBook = Catalog.SelectABook(books);

            Catalog.CheckoutBook(selectedBook);
            break;
        case 2: //list all the books and attempt to check one out
            Console.WriteLine("Here is a List of All Books:");
            Catalog.CheckoutBook(Catalog.SelectABook(Catalog.ListAllBooks()));
            break;
        case 3: //search for a book and attempt to return it
            Catalog.ReturnBook(Catalog.SelectABook(Catalog.ListCheckedOut()));
            break;
        case 4:
            Console.WriteLine("Thank You GoodBye!");
            Catalog.Save();
            return;
        default:
            Console.WriteLine("Invalid choice. Please select 1-4.");
            break;
    }
}

