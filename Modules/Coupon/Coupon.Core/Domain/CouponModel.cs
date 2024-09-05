using Shared.Shared.Core.Enum.CouponEnum;

namespace Coupons.Service.Core.Domain
{
    public class CouponModel
    {
        private Guid _id;
        private string _couponCode = default!;
        private double _discountAmount;
        private int _minAmount;
        private string _discountType = CouponDiscountTypes.Percentage.ToString();
        private int _usableAmount = default!;
        private bool _CanBeUsed;


        public Guid Id { get => _id; set => _id = value; }
        public string CouponCode { get => _couponCode; set => _couponCode = value; }
        public double DiscountAmount { get => _discountAmount; set => _discountAmount = value; }
        public int MinAmount { get => _minAmount; set => _minAmount = value; }
        public string DiscountType { get => _discountType; set => _discountType = value; }
        public int UsableAmount
        { get => _usableAmount; set { _usableAmount = value; _CanBeUsed = _usableAmount > 0; } }
        public bool CanBeUsed { get => _CanBeUsed; set => _CanBeUsed = value; }



        public int UseCoupon()
        {
            if (_usableAmount <= 0)
            {
                throw new InvalidOperationException("No usable coupons left.");
            }

            _usableAmount--;
            _CanBeUsed = _usableAmount > 0;
            return _usableAmount;
        }

        public double CalculateDiscount(double totalAmount)
        {
            if (totalAmount >= MinAmount)
            {
                if (DiscountType == CouponDiscountTypes.FixedAmount.ToString())
                {
                    return DiscountAmount;
                }
                else if (DiscountType == CouponDiscountTypes.Percentage.ToString())
                {
                    return totalAmount * (DiscountAmount / 100);
                }
            }
            return 0;
        }
    }
}
