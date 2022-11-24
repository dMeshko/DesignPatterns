using Facade;

Console.Title = "Facade";

var facade = new DiscountFacade();
Console.WriteLine($"Discount percentage for customer with id: {1}: {facade.CalculateDiscountPercentage(1)}");
Console.WriteLine($"Discount percentage for customer with id: {12}: {facade.CalculateDiscountPercentage(12)}");

Console.ReadKey();