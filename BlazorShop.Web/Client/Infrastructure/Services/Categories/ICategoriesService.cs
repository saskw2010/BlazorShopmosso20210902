namespace BlazorShop.Web.Client.Infrastructure.Services.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;
    using Models.Categories;

    public interface ICategoriesService
    {
        Task<IEnumerable<CategoriesListingResponseModel>> All();

        //saeed
        Task<Result> CreateAsync(CategoriesRequestModel model, string filename);

        //mostafa

        Task<Result> UpdateAsync(int id, CategoriesRequestModel model);

        Task<Result> DeleteAsync(int id);

        Task<TModel> DetailsAsync<TModel>(int id)
            where TModel : class;
    }
}
