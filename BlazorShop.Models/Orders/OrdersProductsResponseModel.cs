namespace BlazorShop.Models.Orders
{
    using AutoMapper;

    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

    public class OrdersProductsResponseModel : IMapFrom<OrderProduct>
    {
        public int OrdersProductId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public virtual List<OrdersProductRecipientsmosso> OrdersProductRecipientsmosso { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<OrderProduct, OrdersProductsResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(op => op.Product.Id))
                .ForMember(m => m.Name, m => m
                    .MapFrom(op => op.Product.Name))
             
                .ForMember(m => m.ImageSource, m => m
                    .MapFrom(op => op.Product.ImageSource))
                .ForMember(m => m.Quantity, m => m
                    .MapFrom(op => op.Quantity))
             .ForMember(m => m.OrdersProductId, m => m
                    .MapFrom(op => op.OrdersProductId))
                .ForMember(m => m.Price, m => m
                    .MapFrom(op => op.Product.Price));
    }
}