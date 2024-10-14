using System;

namespace Library_Management_System
{
    public class LibraryAccount
    {
        public User User { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public LibraryAccount(User user)
        {
            User = user;
            CreatedDate = DateTime.Now;
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account for {User.Name} (ID: {User.Id})");
            Console.WriteLine($"Account Type: {(User is Admin ? "Admin" : "Member")}");
            Console.WriteLine($"Created on: {CreatedDate}");
            if (User is Member)
            {
                Console.WriteLine($"Borrowed Books: {User.BorrowedBooks.Count}");
                Console.WriteLine($"Outstanding Fine: {User.OutstandingFine:C}");
            }
            
        }


    }
}