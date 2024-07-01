using LibraryTerminalLab;
using Spectre.Console;
using System.Data;
using System.Net.NetworkInformation;



string[] menuOptions = [
    "Search for a Book:",
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
            AnsiConsole.WriteLine("No previous catalog found, restoring from backup...");
            topic1 = "Creating new catalog";
            Thread.Sleep(100);
        }
        else
        {
            AnsiConsole.WriteLine("Catalog loaded successfully!");
            Thread.Sleep(100);
        }
        // Define tasks
        var task1 = ctx.AddTask($"[green]{topic1}[/]");
        var task2 = ctx.AddTask("[teal]Generating Menu[/]");
        var task3 = ctx.AddTask($"{bribeColor}Bribing Jonathan and Michael[/]");
        while (!ctx.IsFinished)
        {
            task1.Increment(1.43);
            task2.Increment(1.75);
            if (task2.Value > 35)
            {
                if (task3.Value > 50)
                {
                    task3.StopTask();
                    task3.Description("[red]ERROR: Bribe not found[/]");

                }
                else
                    task3.Increment(1.1);
            }
            Thread.Sleep(70);

        }
        Thread.Sleep(1000);
    });

//replaced with above progress bar
//Catalog.Load();

AnsiConsole.Clear();

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
        case 1: //Search for a book and check it out. Expanded version for ease of readability
            List<Book> books = Catalog.SearchBooks();
            Book selectedBook = Catalog.SelectABook(books);
            Catalog.CheckoutOrReturn(selectedBook);
            break;

        case 2: //list all the books and 
            Console.WriteLine("Here is a List of All Books:");
            Catalog.CheckoutOrReturn(Catalog.SelectABook(Catalog.ListAllBooks()));
            break;

        case 3: //search for a book and attempt to return it
            Catalog.CheckoutOrReturn(Catalog.SelectABook(Catalog.ListCheckedOut()));
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

