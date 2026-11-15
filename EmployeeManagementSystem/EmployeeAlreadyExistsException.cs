
namespace EmployeeManagementSystem
{
    public class EmployeeAlreadyExistsException : Exception
    {
        public EmployeeAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
