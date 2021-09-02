namespace BlazorShop.Web.Client.Infrastructure.Services.Categories
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Models;
    using Extensions;
    using Models.Categories;

    public class CategoriesService : ICategoriesService
    {
        private readonly HttpClient http;

        private const string CategoriesPath = "api/categories";
        //mostafa
        private const string CategoriesPathWithSlash = CategoriesPath + "/";
        private const string CategoriesSearchPath = CategoriesPath + "?category={0}";

        public CategoriesService(HttpClient http) => this.http = http;

        public async Task<IEnumerable<CategoriesListingResponseModel>> All()
            => await this.http.GetFromJsonAsync<IEnumerable<CategoriesListingResponseModel>>(CategoriesPath);

        public async Task<Result> CreateAsync(
            CategoriesRequestModel model, string filename)
        {
            var response = await this.http.PostAsJsonAsync(CategoriesPath, model).ToResult(); 
            //var id = await response.Content.ReadFromJsonAsync<int>();

            return response;
        }

        public async Task<Result> UpdateAsync(
            int id, CategoriesRequestModel model)
            => await this.http
                .PutAsJsonAsync(CategoriesPathWithSlash + id, model)
                .ToResult();

        public async Task<Result> DeleteAsync(
            int id)
            => await this.http
                .DeleteAsync(CategoriesPathWithSlash + id)
                .ToResult();

        public async Task<TModel> DetailsAsync<TModel>(
            int id)
            where TModel : class
            => await this.http.GetFromJsonAsync<TModel>(CategoriesPathWithSlash + id);
    }
}
