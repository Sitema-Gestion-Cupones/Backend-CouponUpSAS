using AutoMapper;
using CouponBook.Models;
using CouponBook.Dtos;

namespace CouponBook.Utils
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<CouponUpdateDto, Coupon>()
                .ForMember(dest => dest.Name, opt => opt.Condition(src => src.Name != null))
                .ForMember(dest => dest.Description, opt => opt.Condition(src => src.Description != null))
                .ForMember(dest => dest.ActivationDate, opt => opt.Condition(src => src.ActivationDate != default(DateTime)))
                .ForMember(dest => dest.EndDate, opt => opt.Condition(src => src.EndDate != default(DateTime)))
                .ForMember(dest => dest.RedemptionCount, opt => opt.Condition(src => src.RedemptionCount != default(int)))
                .ForMember(dest => dest.MaxRedemptions, opt => opt.Condition(src => src.MaxRedemptions != default(int)))
                .ForMember(dest => dest.DiscountType, opt => opt.Condition(src => src.DiscountType != null))
                .ForMember(dest => dest.DiscountValue, opt => opt.Condition(src => src.DiscountValue != default(decimal)))
                .ForMember(dest => dest.UpdateDate, opt => opt.Condition(src => src.UpdateDate != default(DateTime)))
                .ForMember(dest => dest.Category, opt => opt.Condition(src => src.Category != null))
                .ForMember(dest => dest.ValueFrom, opt => opt.Condition(src => src.ValueFrom.HasValue))
                .ForMember(dest => dest.MaxRedemptionsPerUser, opt => opt.Condition(src => src.MaxRedemptionsPerUser != default(int)));

            CreateMap<CouponStatusUpdateDto, Coupon>()
                .ForMember(dest => dest.Status, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Status)));
        }
    }
}
