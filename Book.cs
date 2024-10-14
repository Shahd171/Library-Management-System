using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Book
    {
        public string ISBN { get;  set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CopiesAvailable { get; set; }
        public double FineAmount { get; set; }
        public Book(string isbn, string title, string author, int copiesAvailable, double fineAmount)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            CopiesAvailable = copiesAvailable;
            FineAmount = fineAmount;
        }
        public static bool operator ==(Book a, Book b)
        {

            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.ISBN == b.ISBN;

        }
        public static bool operator !=(Book a, Book b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                return this == book;
            }
            return false;
        }
        public double CalculateFine(int overdueDays)
        {
            return overdueDays * FineAmount;
        }
    }
}
