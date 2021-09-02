

namespace BlazorShop.Web.Client.Pages.Categories
{
    using BlazorShop.Models.Categories;
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public partial class Updatecat
    {
        private CategoriesRequestModel model;
        private IEnumerable<CategoriesListingResponseModel> categories;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {


            this.model = await this.CategoriesService.DetailsAsync<CategoriesRequestModel>(this.Id);
            this.categories = await this.CategoriesService.All();
        }

        private async Task SubmitAsync()
        {
            var result = await this.CategoriesService.UpdateAsync(this.Id, this.model);

            if (result.Succeeded)
            {
                this.NavigationManager.NavigateTo($"/Categories/categorylist");
                //this.NavigationManager.NavigateTo($"/Categories/{this.Id}/{this.model.Name}");
            }
        }
    }
}
