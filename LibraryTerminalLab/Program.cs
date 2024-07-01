using LibraryTerminalLab;
using Spectre.Console;
using System.Net.NetworkInformation;



string[] menuOptions = [
    "Search for a Book to check out:",
    "List All Books:",
    "Return a Book:",
    "Exit:"
   ];

//fun progress bar
AnsiConsole.Progress()
    .Start(ctx =>
    {
        string topic1 = "Loading catalog";

        var bribeColor = "[blue]";

        if (!Catalog.Load())
        {
            topic1 = "Creating new catalog";
        }
        // Define tasks
        var task1 = ctx.AddTask($"[green]{topic1}[/]");
        var task2 = ctx.AddTask("[teal]Generating Menu[/]");
        var task3 = ctx.AddTask($"{bribeColor}Bribing Jonathan and Michael[/]");
        while (!ctx.IsFinished)
        {
            task1.Increment(1.43);
            task2.Increment(1.75);

            Thread.Sleep(70);
            if (task3.Value > 50)
            {
                task3.StopTask();
                task3.Description("[red]ERROR: Bribe not found[/]");
            }
            else
                task3.Increment(1.1);
        }
    });

//replaced with above progress bar
//Catalog.Load();


//artsy title text
var mainTitle = 
    new FigletText("Welcome to the Library Terminal")
        .Centered()
        .Color(Color.Red);

while (true)
{

    AnsiConsole.Write(mainTitle);
    var userSelection = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Please select an option below:")
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

