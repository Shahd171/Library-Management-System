using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public abstract class User
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public double OutstandingFine { get; protected set; }
        public double ExcessPayment { get; protected set; }
        public List<Book> BorrowedBooks { get; private set; }

        public User(string name, string id)
        {
            Name = name;
            Id = id;
            OutstandingFine = 0;
            ExcessPayment = 0;
            BorrowedBooks = new List<Book>();
        }

        public abstract void PayFine();

        public virtual void Borrow(Book book)
        {
            if (OutstandingFine > 0)
            {
                Console.WriteLine($"You have an outstanding fine of {OutstandingFine:C}. You need to pay it before borrowing more books.");
                Console.Write("Would you like to pay the fine now? (Y/N): ");
                string payFineChoice = Console.ReadLine()?.ToUpper();
                if (payFineChoice == "Y")
                {
                    PayFine();
                }
                else
                {
                    Console.WriteLine("You cannot borrow books until the fine is paid.");
                    return;
                }
            }

            if (book.CopiesAvailable > 0)
            {
                book.CopiesAvailable--;
                BorrowedBooks.Add(book);
                Console.WriteLine($"{Name} borrowed {book.Title}.");
            }
            else
            {
                Console.WriteLine("No copies available.");
            }
        }

        public virtual void Return(Book book, int overdueDays = 0)
        {
            if (BorrowedBooks.Contains(book))
            {
                BorrowedBooks.Remove(book);
                book.CopiesAvailable++;
                Console.WriteLine($"{Name} returned {book.Title}.");

                if (overdueDays > 0)
                {
                    double fine = book.CalculateFine(overdueDays);
                    AddFine(fine);
                    Console.WriteLine($"You have an overdue fine of {fine:C} for {overdueDays} day(s).");
                }
            }
            else
            {
                Console.WriteLine($"{Name} did not borrow {book.Title}.");
            }
        }

        public void AddFine(double amount)
        {
            OutstandingFine += amount;
            Console.WriteLine($"{Name} has an outstanding fine of {OutstandingFine:C}.");
        }

        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count > 0)
            {
                Console.WriteLine($"\n{Name}'s borrowed books:");
                foreach (Book book in BorrowedBooks)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN})");
                }
            }
            else
            {
                Console.WriteLine($"{Name} has not borrowed any books.");
            }
        }

        public abstract void DisplayMenu(Library library, List<LibraryAccount> accounts);


    }
}
