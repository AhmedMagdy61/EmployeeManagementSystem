using EmployeeManagementSystem;
using Serilog;
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("Employee Management System Started");

//Console.WriteLine("================================");
//Console.WriteLine("   Employee Management System");
//Console.WriteLine("================================");

//Console.WriteLine("Welcome to Employee Management System!");
//Console.WriteLine("================================");

//Employee employee = new Employee(1, "Ahmed", 10000);

//employee.DisplayInfo();

//Console.WriteLine("--------------------");

//Employee manager = new Manager(1, "Ahmed", 15000, 5000);

//Employee developer = new Developer(2, "Mohamed", 12000, "C#");

//manager.DisplayInfo();

//Console.WriteLine("--------------------");

//developer.DisplayInfo();
//Console.ReadKey();

List<Employee> employees = new List<Employee>();

bool isRunning = true;
try
{
    while (isRunning)
    {
        Console.WriteLine("\n===== Employee Management System =====");
        Console.WriteLine("1. Add Manager");
        Console.WriteLine("2. Add Developer");
        Console.WriteLine("3. Display All Employees");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine() ?? "";


        try
        {
            switch (choice)
            {
                case "1":
                    int managerId = ReadUniqueId(employees);

                    string managerName = ReadName();

                    decimal managerSalary = ReadPositiveSalary("Enter Salary: ");

                    decimal bonus = ReadPositiveSalary("Enter Bonus: ");

                    employees.Add(new Manager(
                        managerId, managerName, managerSalary, bonus));

                    Console.WriteLine("Manager added successfully!");
                    Log.Information("Manager added: {EmployeeId}", managerId);
                    break;

                case "2":
                    int developerId = ReadUniqueId(employees);

                    string developerName = ReadName();

                    decimal developerSalary = ReadPositiveSalary("Enter Salary: ");

                    Console.Write("Enter Programming Language: ");
                    string language = Console.ReadLine()!;

                    employees.Add(new Developer(
                        developerId, developerName, developerSalary, language));

                    Console.WriteLine("Developer added successfully!");
                    Log.Information("Developer added: {EmployeeId}", developerId);
                    break;

                case "3":
                    if (employees.Count == 0)
                    {
                        Console.WriteLine("No employees found.");
                    }
                    else
                    {
                        foreach (Employee employee in employees)
                        {
                            Console.WriteLine("\n--------------------");
                            employee.DisplayInfo();
                        }
                    }
                    break;

                case "4":
                    isRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
        catch (EmployeeAlreadyExistsException ex)
        {
            Console.WriteLine($"Business Error: {ex.Message}");
            Log.Warning("Business Error:: {ErrorMessage}", ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
            Log.Error(ex, "Unexpected error,{ErrorMessage}", ex.Message);
        }

    }
}
finally
{
    Log.Information("Employee Management System Stopped");
    Log.CloseAndFlush();
}


string ReadName()
{
    while (true)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(name) &&
            name.Any(char.IsLetter) &&
            name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            return name;
        }

        Console.WriteLine("Invalid name! Use letters only.");
    }
}


int ReadUniqueId(List<Employee> employees)
{
    while (true)
    {
        Console.Write("Enter ID: ");
        string input = Console.ReadLine() ?? "";

        if (!int.TryParse(input, out int id) || id <= 0)
        {
            Console.WriteLine("Invalid ID!");
            continue;
        }

        try
        {
            if (employees.Any(e => e.Id == id))
            {
                throw new EmployeeAlreadyExistsException(
                    $"Employee with ID {id} already exists!");
            }

            return id;
        }
        catch (EmployeeAlreadyExistsException ex)
        {
            Console.WriteLine($"Business Error: {ex.Message}");
            Log.Warning("Duplicate employee ID: {ErrorMessage}", ex.Message);
        }
    }
}


decimal ReadPositiveSalary(string message)
{
    while (true)
    {
        Console.Write(message);

        string input = Console.ReadLine() ?? "";

        if (!decimal.TryParse(input, out decimal amount))
        {
            Console.WriteLine("Please enter a valid number.");
            continue;
        }

        if (amount < 0)
        {
            Console.WriteLine("Amount cannot be negative!");
            continue;
        }

        return amount;
    }
}


