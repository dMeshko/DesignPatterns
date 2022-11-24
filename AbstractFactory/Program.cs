using AbstractFactory;

Console.Title = "AbstractFactory";

var belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
var macedonianShoppingCartPurchaseFactory = new MacedonianShoppingCartPurchaseFactory();

Console.WriteLine(nameof(belgiumShoppingCartPurchaseFactory));
var shoppingCard = new ShoppingCart(belgiumShoppingCartPurchaseFactory);
shoppingCard.CalculateCosts();

Console.WriteLine(nameof(macedonianShoppingCartPurchaseFactory));
shoppingCard = new ShoppingCart(macedonianShoppingCartPurchaseFactory);
shoppingCard.CalculateCosts();

Console.ReadKey();