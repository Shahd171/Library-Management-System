# Library Management System 📚

A **simple Library Management System** built using **C#** to manage book loans, returns, fines, and more. This project demonstrates Object-Oriented Programming (OOP) concepts such as inheritance, abstraction, and polymorphism while implementing real-world functionalities for both **admin** and **member** roles.

## Features 🎯

### Admin Features:
- Add, remove, and update books in the library.
- View all books available in the library.
- View all users' information (name, borrowed books, and fines).

### Member Features:
- Borrow and return books.
- Pay fines for overdue books.
- View borrowed books.

### Library Features:
- Display available books.
- Track book copies and overdue fines.
- Support overdue fine payments.

## Classes & Key Concepts 🧠
- **User**: Base class for all users (Admin and Member). Manages user info, borrowed books, and fines.
- **Admin**: Inherits from `User`. Manages books (add, update, remove).
- **Member**: Inherits from `User`. Can borrow and return books, pay fines, and view borrowed books.
- **Library**: Manages book operations and keeps track of borrowing, returning, and fines.
- **Book**: Represents a book (ISBN, title, author, available copies).
- **LibraryAccount**: Holds user account details and account creation date.

## Technologies Used 🛠️
- C#
- .NET Core / .NET Framework
- Object-Oriented Programming (OOP)

## How to Run 🚀
1. Install .NET Core or .NET Framework.
2. Open the project in your preferred C# IDE (e.g., Visual Studio, Visual Studio Code).
3. Build and run the project.

## Requirements ✅
- .NET Core or .NET Framework (for C#)
- C# IDE (Visual Studio / VS Code)

