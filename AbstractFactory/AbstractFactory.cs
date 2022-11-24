// Provides an interface for creating families of related or dependent objects without specifying their concrete classes
namespace AbstractFactory
{
    /// <summary>
    /// AbstractFactory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostService CreateShippingCostService();
    }

    /// <summary>
    /// ConcreteFactory1
    /// </summary>
    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new BelgiumShippingCostService();
        }
    }

    /// <summary>
    /// ConcreteFactory2
    /// </summary>
    public class MacedonianShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new MacedonianDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new MacedonianShippingCostService();
        }
    }

    /// <summary>
    /// AbstractProductA
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    /// <summary>
    /// ConcreteProductA1
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    /// <summary>
    /// ConcreteProductA2
    /// </summary>
    public class MacedonianDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    /// <summary>
    /// AbstractProductB
    /// </summary>
    public interface IShippingCostService
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// ConcreteProductB1
    /// </summary>
    public class BelgiumShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// ConcreteProductB2
    /// </summary>
    public class MacedonianShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts => 10;
    }

    /// <summary>
    /// Client
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;
        private readonly int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory shoppingCartPurchaseFactory)
        {
            _discountService = shoppingCartPurchaseFactory.CreateDiscountService();
            _shippingCostService = shoppingCartPurchaseFactory.CreateShippingCostService();
            
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            var discount = _orderCosts / 100 * _discountService.DiscountPercentage;
            var shippingCost = _shippingCostService.ShippingCosts;

            Console.WriteLine($"Total costs = { _orderCosts - discount + shippingCost }");
        }
    }
}
