// Provides a unified interface to a set of interfaces in a subsystem.
// This pattern defines a higher-level interface that makes the subsystem easier to use
namespace Facade
{
    /// <summary>
    /// SubSystem
    /// </summary>
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            return customerId > 5;
        }
    }

    /// <summary>
    /// SubSystem
    /// </summary>
    public class CustomerDiscountBaseService
    {
        public double CalculateDiscountBase(int customerId)
        {
            return customerId > 8 ? 10 : 20;
        }
    }

    /// <summary>
    /// SubSystem
    /// </summary>
    public class DayOfTheWeekFactorService
    {
        public double CalculateDayOfTheWeekFactor()
        {
            switch (DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 0.8;
                default:
                    return 1.2;
            }
        }
    }

    /// <summary>
    /// Facade
    /// </summary>
    public class DiscountFacade
    {
        private readonly OrderService _orderService = new();
        private readonly CustomerDiscountBaseService _discountBaseService = new ();
        private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new ();

        public double CalculateDiscountPercentage(int customerId)
        {
            if (!_orderService.HasEnoughOrders(customerId))
            {
                return 0;
            }

            return _discountBaseService.CalculateDiscountBase(customerId) *
                   _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
        }
    }
}
