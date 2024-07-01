using System;
using System.Collections.Generic;
using Library;
using LibraryTerminalLab;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Library Terminal");

        while (true)
        {
            Console.WriteLine("1. Search for a Book to check out");
            Console.WriteLine("2. List All Books");
            Console.WriteLine("3. Return a Book");
            Console.WriteLine("4. Exit");
            Console.Write("Please Select a Choice: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Write("Enter title, author, or genre to search: ");
                    string searchQuery = Console.ReadLine();
                    List<Book> searchResults = Catalog.SearchBooks(searchQuery);

                    if (searchResults.Count > 0)
                    {
                        Console.WriteLine("Search Results:");
                        for (int i = 0; i < searchResults.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {searchResults[i]}");
                        }

                        Console.Write("Select a book number to check out: ");
                        if (int.TryParse(Console.ReadLine(), out int bookIndex) && bookIndex > 0 && bookIndex <= searchResults.Count)
                        {
                            Catalog.CheckoutBook(searchResults[bookIndex - 1]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matching results found.");
                    }
                    break;

                case "2":
                    Console.WriteLine("List of All Books:");
                    List<Book> allBooks = Catalog.ListAllBooks();
                    foreach (var book in allBooks)
                    {
                        Console.WriteLine(book);
                    }
                    break;

                case "3":
                    Console.Write("Enter the title of the book to return: ");
                    string returnTitle = Console.ReadLine();
                    Book bookToReturn = Catalog.ListAllBooks().FirstOrDefault(b => b.Title.Equals(returnTitle, StringComparison.InvariantCultureIgnoreCase));

                    if (bookToReturn != null)
                    {
                        Catalog.ReturnBook(bookToReturn);
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Thank You. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please select 1-4.");
                    break;
            }
        }
    }
}
