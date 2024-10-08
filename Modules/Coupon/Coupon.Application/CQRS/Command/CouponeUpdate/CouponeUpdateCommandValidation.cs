using FluentValidation;
using Shared.Shared.Core.Enum.CouponEnum;

namespace Coupon.Service.Application.CQRS.Command.CouponeUpdate
{
    public class CouponeUpdateCommandValidation : AbstractValidator<CouponeUpdateCommand>
    {
        public CouponeUpdateCommandValidation()
        {
            RuleFor(request => request.CouponeRequest.CouponCode)
               .NotEmpty().WithMessage("Coupon code is required.")
               .Length(5, 20).WithMessage("Coupon code must be between 5 and 20 characters.");

            RuleFor(request => request.CouponeRequest.DiscountAmount)
                .GreaterThan(0).WithMessage("Discount amount must be greater than zero.");

            RuleFor(request => request.CouponeRequest.MinAmount)
                .GreaterThan(0).WithMessage("Minimum amount must be greater than zero.");

            RuleFor(request => request.CouponeRequest.DiscountType)
                .Must(BeValidDiscountType).WithMessage("Invalid discount type.");

            RuleFor(request => request.CouponeRequest.UsableAmount)
                .GreaterThan(0).WithMessage("Usable amount must be greater than zero.");
        }
        private bool BeValidDiscountType(string discountType)
        {
            return Enum.TryParse(typeof(CouponDiscountTypes), discountType, out _);
        }


    }
}