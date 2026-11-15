
namespace EmployeeManagementSystem
{
    public class Manager : Employee
    {
        private decimal bonus;

        public decimal Bonus
        {
            get { return bonus; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(value), "Bonus cannot be negative.");

                bonus = value;
            }
        }

        public Manager(int id, string name, decimal salary, decimal bonus)
            : base(id, name, salary)
        {
            Bonus = bonus;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Bonus: {Bonus}");
            Console.WriteLine($"Total Salary: {Salary + Bonus}");
        }
    }
}
