namespace LibraryTerminalLab;

public class Catalog
{

    public List<Book> BookList = new List<Book>
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
   }
