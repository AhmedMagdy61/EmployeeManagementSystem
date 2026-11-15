
namespace EmployeeManagementSystem
{
    public class Employee
    {
        // Private fields - Encapsulation
        private int id;
        private string name = string.Empty;
        private decimal salary;

        // Constructor
        public Employee(int id, string name, decimal salary)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be greater than zero.");

            this.id = id;
            Name = name;
            Salary = salary;
        }

        // Public Properties
        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");

                name = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(value), "Salary cannot be negative.");

                salary = value;
            }
        }

        // Method
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }
}
