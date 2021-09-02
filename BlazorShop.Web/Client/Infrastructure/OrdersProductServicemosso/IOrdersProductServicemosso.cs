using BlazorShop.Data;
using BlazorShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Web.Client.Infrastructure.Services.OrdersProductServicemosso
{
    interface IOrdersProductServicemosso
    {
        List<OrderProduct> OrderProductmosso { get; set; }

         Task<List<OrderProduct>> GetOrderProductslist();

        Task<OrderProduct> GetOrderProductbyorderid(int OrdersProductId);

        //Task<ActionResult<OrderProduct>> Get(int id);

        //Task<ActionResult<int>> Post(OrderProduct OrderProduct);

        //Task<ActionResult> Put(OrderProduct OrderProduct);

    }
}
