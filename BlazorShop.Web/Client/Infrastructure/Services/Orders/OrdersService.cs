using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using BlazorShop.Models.Orders;

namespace BlazorShop.Web.Client.Infrastructure.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly HttpClient http;

        private const string OrdersPath = "api/orders";
        private const string OrdersPath1 = "api/allorders";
        
        private const string OrdersPathWithSlash = OrdersPath + "/";
               
        public OrdersService(HttpClient http) => this.http = http;

        
        //[HttpGet]
        //public async Task<ActionResult<List<OrdersProductmosso>>> Get()
        //{
        //    return await this.http.GetFromJsonAsync<List<OrdersProductmosso>>(OrdersPath);
        //    //return await context.OrdersProductmosso.ToListAsync();
        //}


        public async Task<string> Purchase(OrdersRequestModel model)
        {
            var orderResponse = await this.http.PostAsJsonAsync(OrdersPath, model);
            var orderId = await orderResponse.Content.ReadAsStringAsync();

            return orderId;
        }

        public async Task<OrdersDetailsResponseModel> Details(string id)
            => await this.http.GetFromJsonAsync<OrdersDetailsResponseModel>(OrdersPathWithSlash + id);

        public async Task<IEnumerable<OrdersListingResponseModel>> Mine()
            => await this.http.GetFromJsonAsync<IEnumerable<OrdersListingResponseModel>>(OrdersPath);

        public async Task<IEnumerable<OrdersListingmossoResponseModel>> Allorders()
        {
            return await this.http.GetFromJsonAsync<IEnumerable<OrdersListingmossoResponseModel>>(OrdersPath1);
        }

        public async Task<IEnumerable<OrderProduct>> Minemosso()
        {
            var response= await this.http.GetFromJsonAsync<IEnumerable<OrderProduct>>(OrdersPath);

            return response;
        }
         
    }
}
