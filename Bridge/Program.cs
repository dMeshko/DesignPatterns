using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuroCoupon();

var meatMenu = new MeatMenu(noCoupon);
Console.WriteLine($"Meat menu, no coupon: {meatMenu.CalculatePrice()} euro.");

meatMenu = new MeatMenu(oneEuroCoupon);
Console.WriteLine($"Meat menu, one euro coupon: {meatMenu.CalculatePrice()} euro.");

var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian menu, no coupon: {vegetarianMenu.CalculatePrice()} euro.");

vegetarianMenu = new VegetarianMenu(oneEuroCoupon);
Console.WriteLine($"Vegetarian menu, one euro coupon: {vegetarianMenu.CalculatePrice()} euro.");

Console.ReadKey();