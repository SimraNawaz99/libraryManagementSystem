create database LibraryManagementSystem;
use LibraryManagementSystem;
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(20) NOT NULL, -- Admin or Customer
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20)
);
CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Author NVARCHAR(100),
    Category NVARCHAR(50),
    ISBN NVARCHAR(50),
    Quantity INT NOT NULL
);
CREATE TABLE BorrowRecords (
    BorrowId INT PRIMARY KEY IDENTITY,
    BookId INT FOREIGN KEY REFERENCES Books(BookId),
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    BorrowDate DATETIME NOT NULL,
    ReturnDate DATETIME,
    IsReturned BIT DEFAULT 0
);
select * from Books;
select * from Users;
select * from BorrowRecords;