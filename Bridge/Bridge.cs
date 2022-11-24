// Decouples an abstraction from its implementation so that the two can vary independently
namespace Bridge
{
    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICoupon Coupon = null!;
        public abstract int CalculatePrice();

        protected Menu(ICoupon coupon)
        {
            Coupon = coupon;
        }
    }

    /// <summary>
    /// RefinedAbstraction
    /// </summary>
    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 20 - Coupon.CouponValue;
        }
    }

    /// <summary>
    /// RefinedAbstraction
    /// </summary>
    public class MeatMenu : Menu
    {
        public MeatMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 30 - Coupon.CouponValue;
        }
    }

    /// <summary>
    /// Implementor
    /// </summary>
    public interface ICoupon
    {
        public int CouponValue { get; }
    }

    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class NoCoupon : ICoupon
    {
        public int CouponValue => 0;
    }

    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue => 1;
    }

    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue => 2;
    }
}
