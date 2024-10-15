using Library_Management_System;
using System.Xml.Linq;

public class Admin : User
{
    public Admin(string name, string id) : base(name, id) { }

    public void AddBookToLibrary(Library library)
    {
        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Author: ");
        string author = Console.ReadLine();
        Console.Write("Enter Copies Available: ");
        int copiesAvailable = int.Parse(Console.ReadLine());
        Console.Write("Enter Fine Amount: ");
        double fineAmount = double.Parse(Console.ReadLine());

        Book newBook = new Book(isbn, title, author, copiesAvailable, fineAmount);
        library.AddBook(this, newBook);
    }

    public void UpdateBookInLibrary(Library library)
    {
        Console.Write("Enter ISBN of the book to update: ");
        string isbn = Console.ReadLine();
        Console.Write("Enter new Title: ");
        string newTitle = Console.ReadLine();
        Console.Write("Enter new Author: ");
        string newAuthor = Console.ReadLine();
        Console.Write("Enter new Copies Available: ");
        int newCopiesAvailable = int.Parse(Console.ReadLine());
        Console.Write("Enter new Fine Amount: ");
        double newFineAmount = double.Parse(Console.ReadLine());

        library.UpdateBook(this, isbn, newTitle, newAuthor, newCopiesAvailable, newFineAmount);
    }

    public void RemoveBookFromLibrary(Library library)
    {
        Console.Write("Enter ISBN of the book to remove: ");
        string isbn = Console.ReadLine();
        library.RemoveBook(this, isbn);
    }

    public override void PayFine()
    {
        Console.WriteLine($"{Name} (Admin) does not handle fines.");
    }

    public override void DisplayMenu(Library library, List<LibraryAccount> accounts)
    {
        while (true)
        {
            Console.WriteLine($"\nWelcome, Admin {Name}!");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Display All Books");
            Console.WriteLine("5. Show User Data");
            Console.WriteLine("6. Logout");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBookToLibrary(library);
                    break;
                case "2":
                    RemoveBookFromLibrary(library);
                    break;
                case "3":
                    UpdateBookInLibrary(library);
                    break;
                case "4":
                    library.DisplayAllBooks();
                    break;
                case "5":
                    DisplayUserInfo(accounts);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayUserInfo(List<LibraryAccount> accounts)
    {
        Console.WriteLine("\nUser Information:");
        foreach (var account in accounts)
        {
            account.DisplayAccountInfo();
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }
}