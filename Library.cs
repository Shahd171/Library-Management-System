using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management_System
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }
        public List<Book> GetAllBooks()
        {
            return books;
        }
        

        public Book FindBookByISBN(string isbn)
        {
            return books.Find(b => b.ISBN == isbn);
        }

        public void BorrowBook(User user, string isbn)
        {
            Book book = FindBookByISBN(isbn);
            if (book != null)
            {
                user.Borrow(book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void BorrowBookByTitle(User user, string title)
        {
            Book book = books.Find(b => b.Title == title);
            if (book != null)
            {
                user.Borrow(book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void ReturnBook(User user, string isbn)
        {
            Book book = FindBookByISBN(isbn);
            if (book != null)
            {
                user.Return(book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        public void DisplayAllBooks()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("\nBooks available in the library:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN}), Copies Available: {book.CopiesAvailable}");
                }
            }
            else
            {
                Console.WriteLine("No books are available in the library.");
            }
        }
        public void AddBook(User user, Book book)
        {
            if (user is Admin)
            {
                // Check if the book already exists
                if (books.Exists(b => b.ISBN == book.ISBN))
                {
                    Console.WriteLine($"Book '{book.Title}' already exists in the library.");
                    return;
                }

                books.Add(book);
                Console.WriteLine($"Admin {user.Name} added '{book.Title}' to the library.");
            }
            else
            {
                Console.WriteLine("Permission denied: Only Admins can add books.");
            }
        }

        public void RemoveBook(User user, string isbn)
        {
            if (user is Admin) 
            {
                Book book = FindBookByISBN(isbn);
                if (book != null)
                {
                    books.Remove(book);
                    Console.WriteLine($"Admin {user.Name} removed '{book.Title}' from the library.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Permission denied: Only Admins can remove books.");
            }
        }
        public void UpdateBook(User user, string isbn, string newTitle, string newAuthor, int newCopiesAvailable, double newFineAmount)
        {
            if (user is Admin)
            {
                var book = FindBookByISBN(isbn);
                if (book != null)
                {
                    book.Title = newTitle;
                    book.Author = newAuthor;
                    book.CopiesAvailable = newCopiesAvailable;
                    book.FineAmount = newFineAmount;
                    Console.WriteLine($"Admin {user.Name} updated the book '{book.Title}' (ISBN: {isbn}).");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Permission denied: Only Admins can update books.");
            }
        }
    
}
    }
