using LibraryTerminalLab;
using System.Net.NetworkInformation;


Console.WriteLine("Welcome to Library Terminal");
Console.WriteLine("1.Search for a Book:");
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
            Console.WriteLine("What book are you looking for? (Title/Author/Genre)");
            string Input = Console.ReadLine();
            //pending merger from method
            //bool bookFound = Catalog.SearchBooks(Input);

            //if (!bookFound) 
                Console.WriteLine("Sorry Invaild input please try again.");
            break;
        case "2":
            Console.WriteLine("Here is a List of All Books:");
            Catalog.ListAllBooks();
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

