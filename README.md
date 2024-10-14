# Library Management System

A simple Library Management System built using C# that allows users (members and admins) to manage book loans, returns, fines, and more. Admins can add, remove, and update books in the library, while members can borrow and return books.

## Features

### Admin Features:
- Add, remove, and update books.
- Display all books in the library.

### Member Features:
- Borrow and return books.
- Pay fines for overdue books.
- View borrowed books.

### Library Features:
- Display available books.
- Track books' copies and fine amounts.
- Support for overdue fines.

## Classes and Key Concepts

### `User`
- Base class for all users (Admin and Member).
- Manages user information, borrowed books, and fines.

### `Admin`
- Inherits from `User`.
- Has additional capabilities for managing books in the library.

### `Member`
- Inherits from `User`.
- Can borrow and return books, pay fines, and view borrowed books.

### `Library`
- Manages books in the library.
- Handles book borrowing, returning, and updating operations.

### `Book`
- Represents a book in the library.
- Contains details like ISBN, title, author, and copies available.

### `Publisher`
- Represents the publisher who publishes books.

### `LibraryAccount`
- Represents a user account containing user details and account creation date.

## Requirements
- .NET Core or .NET Framework (for C#)
- A C# IDE (like Visual Studio or Visual Studio Code)

