using Library_Management_System;
using System.Xml.Linq;

public class Member : User
{
    public Member(string name, string id) : base(name, id) { }

    public override void PayFine()

    {
      
        if (OutstandingFine > 0)
        {
            Console.WriteLine($"{Name}, you have an outstanding fine of {OutstandingFine:C}.");
            Console.Write("Enter the payment amount: ");
            double paymentAmount = double.Parse(Console.ReadLine());

            if (paymentAmount >= OutstandingFine)
            {
                ExcessPayment = paymentAmount - OutstandingFine;
                OutstandingFine = 0;
                Console.WriteLine($"Fine fully paid! Excess payment: {ExcessPayment:C}.");
            }
            else
            {
                OutstandingFine -= paymentAmount;
                Console.WriteLine($"Partial payment made. Remaining fine: {OutstandingFine:C}.");
            }
        }
        else
        {
            Console.WriteLine("You have no outstanding fines.");
        }
    }

    public override void Borrow(Book book)
    {
        if (BorrowedBooks.Count >= 3)
        {
            Console.WriteLine($"{Name} (Member) cannot borrow more than 3 books.");
            return;
        }

        base.Borrow(book);
    }

    public void BorrowFromLibrary(Library library)
    {
        Console.Write("Enter ISBN of the book to borrow: ");
        string isbn = Console.ReadLine();
        library.BorrowBook(this, isbn);
    }

    public void ReturnToLibrary(Library library)
    {
        Console.Write("Enter ISBN of the book to return: ");
        string isbn = Console.ReadLine();
        Console.Write("Enter number of overdue days (0 if not overdue): ");
        int overdueDays = int.Parse(Console.ReadLine());

        Book book = library.FindBookByISBN(isbn);
        if (book != null)
        {
            Return(book, overdueDays);
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public override void DisplayMenu(Library library, List<LibraryAccount> accounts)
    {
        while (true)
        {
            Console.WriteLine($"\nWelcome, {Name}!");
            Console.WriteLine("1. Borrow Book");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. Display Borrowed Books");
            Console.WriteLine("4. Pay Fine");
            Console.WriteLine("5. Logout");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BorrowFromLibrary(library);
                    break;
                case "2":
                    ReturnToLibrary(library);
                    break;
                case "3":
                    DisplayBorrowedBooks();
                    break;
                case "4":
                    PayFine();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
