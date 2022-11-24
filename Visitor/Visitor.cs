// Represents an operation to be performed on the elements of an object structure.
// This patterns lets you define a new operation without changing the classes of the elements on which it operates
namespace Visitor
{
    /// <summary>
    /// ConcreteElement
    /// </summary>
    public class Customer : IElement
    {
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; set; }

        public Customer(decimal amountOrdered, string name)
        {
            AmountOrdered = amountOrdered;
            Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCustomer(this);
            Console.WriteLine($"Visited {GetType()} {Name}, discount given: {Discount}");
        }
    }

    /// <summary>
    /// ConcreteElement
    /// </summary>
    public class Employee : IElement
    {
        public int YearsEmployed { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Employee(int yearsEmployed, string name)
        {
            YearsEmployed = yearsEmployed;
            Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitEmployee(this);
            Console.WriteLine($"Visited {GetType()} {Name}, discount given: {Discount}");
        }
    }

    /// <summary>
    /// Element
    /// </summary>
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// Visitor
    /// </summary>
    public interface IVisitor
    {
        void VisitCustomer(Customer customer);
        void VisitEmployee(Employee employee);
    }

    /// <summary>
    /// ConcreteVisitor
    /// </summary>
    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; private set; } = 0;

        public void VisitCustomer(Customer customer)
        {
            var discount = customer.AmountOrdered / 10;
            customer.Discount = discount;
            TotalDiscountGiven += discount;
        }

        public void VisitEmployee(Employee employee)
        {
            var discount = employee.YearsEmployed < 10 ? 100 : 200;
            employee.Discount = discount;
            TotalDiscountGiven += discount;
        }
    }

    /// <summary>
    /// ObjectStructure
    /// </summary>
    public class Container
    {
        public List<Employee> Employees { get; private set; } = new();
        public List<Customer> Customers { get; private set; } = new();

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in Employees)
            {
                employee.Accept(visitor);
            }

            foreach (var customer in Customers)
            {
                customer.Accept(visitor);
            }
        }
    }
}
