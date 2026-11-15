
# Employee Management System

A simple console-based Employee Management System developed using C# and .NET 9.

## Project Overview

This application allows users to manage different types of employees through a console menu.

Users can:
- Add Managers with salaries and bonuses.
- Add Developers with their programming languages.
- Display all registered employees.
- Validate employee information and prevent duplicate IDs.

## Technologies Used

- C#
- .NET 9
- Serilog
- Object-Oriented Programming (OOP)

## OOP Concepts Applied

- **Encapsulation:** Using private fields and properties to control access to employee data.
- **Inheritance:** Manager and Developer classes inherit from the Employee base class.
- **Polymorphism:** Overriding the DisplayInfo() method to display different employee details.
- **Exception Handling:** Using a custom EmployeeAlreadyExistsException to handle duplicate employee IDs.

## Logging

Serilog is used for logging application events and errors to the console and daily log files.

## Input Validation

- Employee IDs must be positive and unique.
- Employee names must contain valid characters.
- Salaries and bonuses cannot be negative.
- Invalid numeric input is rejected.

## Project Structure

```text
EmployeeManagementSystem/
├── EmployeeManagementSystem.sln
├── .gitignore
├── README.md
└── EmployeeManagementSystem/
    ├── Developer.cs
    ├── Employee.cs
    ├── EmployeeAlreadyExistsException.cs
    ├── Manager.cs
    ├── Program.cs
    └── EmployeeManagementSystem.csproj
```

## How to Run

1. Clone the repository.
2. Open the solution file in Visual Studio.
3. Restore NuGet packages.
4. Run the application.

Or use the .NET CLI:

```bash
dotnet restore
dotnet run --project EmployeeManagementSystem
```

## Author

Ahmed Magdy
