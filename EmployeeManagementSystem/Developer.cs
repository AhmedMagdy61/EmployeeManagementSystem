
namespace EmployeeManagementSystem
{
    public class Developer : Employee
    {
        private string programmingLanguage = string.Empty;

        public string ProgrammingLanguage
        {
            get { return programmingLanguage; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(
                        "Programming language cannot be empty.");

                programmingLanguage = value;
            }
        }

        public Developer(int id, string name, decimal salary, string programmingLanguage)
            : base(id, name, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
        }
    }
}
