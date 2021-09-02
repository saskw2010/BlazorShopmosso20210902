using BlazorShop.Data;
using BlazorShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.OrdersProductServicemosso
{
    public interface IOrdersProductServicemosso
    {
        Task<List<OrderProduct>> GetOrderProductslist();

        Task<OrderProduct> GetOrderProductbyorderid(int OrdersProductId);

        //Task<ActionResult<OrderProduct>> Get(int id);

        //Task<ActionResult<int>> Post(OrderProduct OrderProduct);

        //Task<ActionResult> Put(OrderProduct OrderProduct);
        Task<List<OrdersProductRecipientsmosso>> OrderProductRecipientslist();
        Task<List<OrdersProductRecipientsmosso>> OrderProductRecipientslistbyid(int OrdersProductId);
    }
}
