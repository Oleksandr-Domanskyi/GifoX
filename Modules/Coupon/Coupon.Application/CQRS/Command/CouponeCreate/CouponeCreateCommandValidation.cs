using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Core.Domain.Enums;
using FluentValidation;

namespace Coupon.Service.Application.CQRS.Command.CouponeCreate
{
    public class CouponeCreateCommandValidation : AbstractValidator<CouponeCreateCommand>
    {
        public CouponeCreateCommandValidation()
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
            return Enum.TryParse(typeof(DiscountTypes), discountType, out _);
        }

    }
}