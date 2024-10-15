using System;
using System.Collections.Generic;

namespace Library_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            List<LibraryAccount> accounts = new List<LibraryAccount>();

            // Add some initial books to the library
            library.AddBook(new Admin("System", "SYSTEM"), new Book("1", "The Great Gatsby", "F. Scott Fitzgerald", 5, 0.50));
            library.AddBook(new Admin("System", "SYSTEM"), new Book("2", "To Kill a Mockingbird", "Harper Lee", 3, 0.50));

            while (true)
            {
                Console.WriteLine("\nWelcome to the Library Management System");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Show Library Books");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LoginUser(accounts, library);
                        break;
                    case "2":
                        RegisterUser(accounts);
                        break;
                    case "3":
                        ShowLibraryBooks(library);
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the Library Management System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void LoginUser(List<LibraryAccount> accounts, Library library)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your ID: ");
            string id = Console.ReadLine();

            LibraryAccount account = accounts.Find(a => a.User.Name == name && a.User.Id == id);

            if (account != null)
            {
                account.User.DisplayMenu(library, accounts);
            }
            else
            {
                Console.WriteLine("User not found. Please register or try again.");
            }
        }

        static void RegisterUser(List<LibraryAccount> accounts)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            string id;
            while (true)
            {
                Console.Write("Enter your ID: ");
                id = Console.ReadLine();

                // Check if ID is unique
                if (accounts.Any(a => a.User.Id == id))
                {
                    Console.WriteLine("ID already exists. Please enter a different ID.");
                }
                else
                {
                    break;  // ID is unique
                }
            }
            Console.Write("Are you an admin? (Y/N): ");
            string isAdmin = Console.ReadLine().ToUpper();

            User newUser;
            if (isAdmin == "Y")
            {
                newUser = new Admin(name, id);
                Console.WriteLine("Admin account created successfully.");
            }
            else
            {
                newUser = new Member(name, id);
                Console.WriteLine("Member account created successfully.");
            }

            LibraryAccount newAccount = new LibraryAccount(newUser);
            accounts.Add(newAccount);
        }

        static void ShowLibraryBooks(Library library)
        {
            Console.WriteLine("\nLibrary Book Collection:");
            List<Book> books = library.GetAllBooks();
            if (books.Count > 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Author: {book.Author}, Available Copies: {book.CopiesAvailable}");
                }
            }
            else
            {
                Console.WriteLine("The library currently has no books.");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}