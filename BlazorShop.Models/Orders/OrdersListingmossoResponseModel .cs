namespace BlazorShop.Models.Orders
{
    using AutoMapper;
    using BlazorShop.Common.Mapping;
    using Data.Models;
    using System.Globalization;

    public class OrdersListingmossoResponseModel : IMapFrom<Order>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        //public int Rowcount { get; set; }
        public string UserId { get; set; }
        //public BlazorShopUser User { get; set; }
        public int DeliveryAddressId { get; set; }
        //public Address DeliveryAddress { get; set; }
        public string CreatedOn { get; set; }
        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Order, OrdersListingmossoResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(o => o.Id))
            .ForMember(m => m.UserId, m => m
                    .MapFrom(o => o.UserId))
            .ForMember(m => m.DeliveryAddressId, m => m
                    .MapFrom(o => o.DeliveryAddressId))
            
                .ForMember(m => m.UserName, m => m
                    .MapFrom(op => op.User.UserName))
                .ForMember(m => m.PhoneNumber, m => m
                    .MapFrom(o => o.User.PhoneNumber))
                .ForMember(m => m.CreatedOn, m => m
                    .MapFrom(o => o.CreatedOn.ToString(CultureInfo.InvariantCulture)));
   
      
    }
}
