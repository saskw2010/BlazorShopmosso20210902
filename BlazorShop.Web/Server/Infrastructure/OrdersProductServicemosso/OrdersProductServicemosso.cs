using BlazorShop.Data;
using BlazorShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.OrdersProductServicemosso
{
    public class OrdersProductServicemosso : IOrdersProductServicemosso
    {
        private readonly BlazorShopDbContext _context;

        public OrdersProductServicemosso(BlazorShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderProduct>> GetOrderProductslist()
        {
            return await _context.OrdersProducts.ToListAsync();

        }

        public async Task<OrderProduct> GetOrderProductbyorderid(int OrdersProductId)
        {
            
            var OrderProductobject = await _context.OrdersProducts
                //.Include(x => x.OrdersProductRecipientsmosso)
                .Where(x => x.OrdersProductId == OrdersProductId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return OrderProductobject;
        }
        public async Task<List<OrdersProductRecipientsmosso>> OrderProductRecipientslist()
        {
            return await _context.OrdersProductRecipientsmosso.ToListAsync();
        }

        public async Task<List<OrdersProductRecipientsmosso>> OrderProductRecipientslistbyid(int OrdersProductId)
        {
            var OrderProductobject = await _context.OrdersProductRecipientsmosso
                .Where(x => x.OrdersProductId == OrdersProductId)
                .AsNoTracking()
                .ToListAsync();
            return OrderProductobject;
        }

    }
}
