// Encapsulates a request as an object, thereby letting you parametrize clients with different requests,
// queue or log requests, and support undoable operations
namespace Command
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Manager : Employee
    {
        public List<Employee> Employees { get; set; } = new();

        public Manager(int id, string name) : base(id, name)
        {
        }
    }

    /// <summary>
    /// Receiver (interface)
    /// </summary>
    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, int employeeId);
        void WriteDataStore();
    }

    /// <summary>
    /// Receiver (implementation)
    /// </summary>
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new List<Manager>()
        {
            new Manager(1, "Katie"),
            new Manager(2, "Geoff")
        };

        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Add(employee);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(x => x.Id == managerId).Employees.Remove(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
            return _managers.First(x => x.Id == managerId).Employees.Any(x => x.Id == employeeId);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager id: {manager.Id}. name: {manager.Name}");
                foreach (var employee in manager.Employees)
                {
                    Console.WriteLine($"\t Employee: {employee.Id}, {employee.Name}");
                }

                if (!manager.Employees.Any())
                {
                    Console.WriteLine("\t No employees!");
                }
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Command
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
        bool CanExecute();
    }

    /// <summary>
    /// ConcreteCommand
    /// </summary>
    public class AddEmployeeToManagersList : ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private readonly int _managerId;
        private readonly Employee? employee;

        public AddEmployeeToManagersList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee employee)
        {
            _employeeManagerRepository = employeeManagerRepository;
            _managerId = managerId;
            this.employee = employee;
        }

        public void Execute()
        {
            if (employee == null)
            {
                return;
            }

            _employeeManagerRepository.AddEmployee(_managerId, employee);
        }

        public void Undo()
        {
            if (employee == null)
            {
                return;
            }

            _employeeManagerRepository.RemoveEmployee(_managerId, employee);
        }

        public bool CanExecute()
        {
            if (employee == null)
            {
                return false;
            }

            return !_employeeManagerRepository.HasEmployee(_managerId, employee.Id);
        }
    }

    /// <summary>
    /// Invoker
    /// </summary>
    public class CommandManager
    {
        private readonly Stack<ICommand> _commands = new();

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                command.Execute();
                _commands.Push(command);
            }
        }

        public void Revoke()
        {
            if (_commands.Any())
            {
                _commands.Pop().Undo();
            }
        }

        public void Reset()
        {
            while (_commands.Any())
            {
                _commands.Pop().Undo();
            }
        }
    }
}
