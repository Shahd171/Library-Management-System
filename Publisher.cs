using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Publisher
    {
        public string Name { get; }
        public List<Book> PublishedBooks { get; }

        public Publisher(string name)
        {
            Name = name;
            PublishedBooks = new List<Book>();
        }
        public void PublishBook(Book book)
        {
            PublishedBooks.Add(book);
            Console.WriteLine($"Publisher {Name} published the book: {book.Title}");
        }

        public void DisplayPublishedBooks()
        {
            Console.WriteLine($"Books published by {Name}:");
            foreach (var book in PublishedBooks)
            {
                Console.WriteLine($"- {book.Title}");
            }
        }
    }
}
