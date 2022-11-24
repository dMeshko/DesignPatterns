using FactoryMethod;

Console.Title = "FactoryMethod";

var factories = new List<DiscountFactory>
{
    new CountryDiscountFactory("BE"),
    new CodeDiscountFactory("SOMEcode")
};

foreach (var discountFactory in factories)
{
    var discountService = discountFactory.CreateDiscountService();
    Console.WriteLine($"Percentage: {discountService.DiscountPercentage} coming from {discountService}");
}

Console.ReadKey();