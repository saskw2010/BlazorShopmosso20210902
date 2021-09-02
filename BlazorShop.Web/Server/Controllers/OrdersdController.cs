﻿
using BlazorShop.Data;
using BlazorShop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Server.Services.OrdersProductServicemosso;
using Microsoft.EntityFrameworkCore;
using BlazorShop.Services.Orders;
using BlazorShop.Models.Orders;

namespace BlazorShop.Server.Controllers
{
    //[controller]
    [Route("api/allorders")]
    [ApiController]
    public class OrdersdController : ControllerBase
    {
        private readonly IOrdersService _OrdersServicemosso;
        

        public OrdersdController(IOrdersService OrdersServicemosso)
        {
            _OrdersServicemosso = OrdersServicemosso;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersListingmossoResponseModel>>> Orderslist()
        {
            var Orderslist = await _OrdersServicemosso.Allorders();
            return Ok(Orderslist);
        }

        ////[HttpGet("{id}")]
        ////public async Task<ActionResult<OrderProduct>> Get(int id)
        ////{

        ////    var OrdersProduct = await context.OrdersProducts
        ////        .Include(x => x.OrdersProductRecipientsmosso)
        ////        .FirstOrDefaultAsync(x => x.OrdersProductId == id);

        ////    // var OrdersProduct = OrdersProduct1.
        ////    //

        ////    if (OrdersProduct == null) { return NotFound(); }

        ////    return OrdersProduct;
        ////}

        //[HttpGet("{id}/{backendOnly}")]
        //public IActionResult Get(int id, string backendOnly)
        //{
        //    return Content("id - " + id + " and backendOnly - " + backendOnly);
        //}

        //[Route("details")]
        //[HttpGet]
        //public IActionResult Details(int id, string backendOnly)
        //{
        //    return Content("id - " + id + " and backendOnly - " + backendOnly);
        //}
        //
        //GET request using query parameters
        // https://localhost:44363/api/OrderProduct/details?OrderId=2
        //https://localhost:44363/details?id=2&&first=csharp
        //https://localhost:44363/details?id=2&&first=csharp&&second=mvc
        // [HttpGet("details")]
        //public async Task<ActionResult<OrdersProduct>> Details(int id)
        // {
        //var OrdersProduct = await context.OrdersProducts
        //              .Where(o => o.OrdersProductId == id)
        //        .SelectMany(o => o.OrdersProductRecipientsmosso)
        //    .ToListAsync();
        //    var OrdersProduct = await context.OrdersProducts
        //        .Include(x => x.OrdersProductRecipientsmosso)
        //        .FirstOrDefaultAsync(x => x.OrdersProductId == id);

        //    if (OrdersProduct == null) { return NotFound(); }

        //    return OrdersProduct; 
        //}

        ////[HttpPost]
        ////public async Task<ActionResult<int>> Post(OrderProduct OrderProduct)
        ////{
        ////    context.OrdersProducts.Add(OrderProduct);
        ////    await context.SaveChangesAsync();
        ////    return OrderProduct.OrdersProductId;
        ////}

        ////[HttpPut]
        ////public async Task<ActionResult> Put(OrderProduct OrderProduct)
        ////{
        ////    context.Entry(OrderProduct).State = EntityState.Modified;

        ////    foreach (var IOrderProduct in OrderProduct.OrdersProductRecipientsmosso)
        ////    {
        ////        if (IOrderProduct.OrdersProductId != 0)
        ////        {
        ////            context.Entry(IOrderProduct).State = EntityState.Modified;
        ////        }
        ////        else
        ////        {
        ////            context.Entry(IOrderProduct).State = EntityState.Added;
        ////        }
        ////    }

        ////    var idsOfOrderProductRecipientsmosso = OrderProduct.OrdersProductRecipientsmosso.Select(x => x.OrdersProductId).ToList();
        ////    var OrderProductRecipientsmossoToDelete = await context
        ////        .OrdersProductRecipientsmosso
        ////        .Where(x => !idsOfOrderProductRecipientsmosso.Contains(x.OrdersProductId) && x.OrdersProductId == OrderProduct.OrdersProductId)
        ////        .ToListAsync();

        ////    context.RemoveRange(OrderProductRecipientsmossoToDelete);

        ////    await context.SaveChangesAsync();

        ////    return NoContent();
        ////}

    }
}
