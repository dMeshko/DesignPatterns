using Command;

// Without violating encapsulation, captures and externalizes an object's internal state so that
// the object can be restored to this state later
namespace Memento
{
    /// <summary>
    /// Memento
    /// </summary>
    public class AddEmployeeToManagerListMemento
    {
        public int ManagerId { get; private set; }
        public Employee? Employee { get; private set; }

        public AddEmployeeToManagerListMemento(int managerId, Employee employee)
        {
            ManagerId = managerId;
            Employee = employee;
        }
    }
}
