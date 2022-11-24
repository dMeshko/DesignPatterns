using Prototype;

var manager = new Manager("Cindy");
var managerClone = (Manager) manager.Clone();
Console.WriteLine($"Manager was cloned: {managerClone.Name}");

var employee = new Employee("Kevin", managerClone);
var employeeClone = (Employee) employee.Clone(true);
Console.WriteLine($"Employee was cloned: {employeeClone.Name}, with manager: {employeeClone.Manager.Name}");

// change the manager name - reference change (if the employee is not deep-cloned, it will be updated there too)
managerClone.Name = "Karen";
Console.WriteLine($"Employee was cloned: {employeeClone.Name}, with manager: {employeeClone.Manager.Name}");

Console.ReadKey();