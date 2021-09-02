

namespace BlazorShop.Web.Client.Pages.Categories
{
    using BlazorShop.Models.Categories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Models.Products;

    public partial class CategoryList
    {
        private IEnumerable<ProductsListingResponseModel> products;
        private IEnumerable<CategoriesListingResponseModel> categories;

        protected override async Task OnInitializedAsync()
        {
            var response = await this.Http.GetFromJsonAsync<ProductsSearchResponseModel>("api/products");
            this.products = response.Products;
            categories = await this.CategoriesService.All();
            //this.NavigationManager.NavigateTo("/Categories/CategoryList", forceLoad: true);
        }


        //private IEnumerable<ProductsListingResponseModel> products;
        //private IEnumerable<CategoriesListingResponseModel> categories;

        //protected override async Task OnInitializedAsync()
        //{
        //    var response = await this.Http.GetFromJsonAsync<ProductsSearchResponseModel>("api/products");

        //    this.products = response.Products;
        //    categories = await this.CategoriesService.All();

        //}
    }
}
