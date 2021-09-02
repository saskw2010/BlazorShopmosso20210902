using BlazorShop.Data;
using BlazorShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace BlazorShop.Web.Client.Infrastructure.Services.OrdersProductServicemosso
{
    public class OrdersProductServicemosso : IOrdersProductServicemosso
    {
        private readonly HttpClient _http;

        public List<OrderProduct> OrderProductmosso { get; set; } = new List<OrderProduct>();

        public OrdersProductServicemosso(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<OrderProduct>> GetOrderProductslist()
        {
            OrderProductmosso = await _http.GetFromJsonAsync<List<OrderProduct>>("api/OrderProduct");
            return OrderProductmosso;
        }

        public Task<OrderProduct> GetOrderProductbyorderid(int OrdersProductId)
        {
            throw new NotImplementedException();
        }
    }
}
