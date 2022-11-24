// See https://aka.ms/new-console-template for more information

using Visitor;

Console.Title = "Visitor";

var container = new Container();
container.Customers.Add(new Customer(500, "Darko"));
container.Customers.Add(new Customer(1000, "Zharko"));
container.Customers.Add(new Customer(800, "Marko"));
container.Employees.Add(new Employee(18, "Trajko"));
container.Employees.Add(new Employee(5, "Mirko"));

var discountVisitor = new DiscountVisitor();

container.Accept(discountVisitor);

Console.WriteLine($"Total discount given: {discountVisitor.TotalDiscountGiven}");

Console.ReadKey();
