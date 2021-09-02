namespace BlazorShop.Web.Client.Pages.Orders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
   
    using BlazorShop.Models.Orders;

    public partial class Orderindex
    {
       protected int Rowcount =0;
        private IEnumerable<OrdersListingmossoResponseModel> Ordermossolist;
        protected override async Task OnInitializedAsync()
        { 
             this.Ordermossolist = await this.OrdersService.Allorders();
            //Rowcount= this.Ordermossolist
        }
    }
}
