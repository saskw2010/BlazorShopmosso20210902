namespace BlazorShop.Services.Categories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
   
    using Data;
    using Data.Models;
    using Models;
    using Models.Categories;
    using System;
    //using Specifications;

    public class CategoriesService : BaseService<Category>, ICategoriesService
    {
        //saeed

        private const int CategoriesPerPage = 6;

        public CategoriesService(BlazorShopDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<int> CreateAsync(CategoriesRequestModel model,string filename)
        {
            var category = new Category
            {
                Name = model.Name,
                ImageSource = model.ImageSource
                //model.ImageSource
            };

            await this.Data.AddAsync(category);
            await this.Data.SaveChangesAsync();

            return category.Id;
        }

        public async Task<Result> UpdateAsync(
            int id, CategoriesRequestModel model)
        {
            var category = await this.FindByIdAsync(id);

            if (category == null)
            {
                return false;
            }

            category.Name = model.Name;
            category.ImageSource = model.ImageSource;

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var category = await this.FindByIdAsync(id);

            if (category == null)
            {
                return false;
            }

            this.Data.Remove(category);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CategoriesListingResponseModel>> AllAsync()
            => await this.Mapper
                .ProjectTo<CategoriesListingResponseModel>(this
                    .AllAsNoTracking())
                .ToListAsync();

        private async Task<Category> FindByIdAsync(
            int id)
            => await this
                .All()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

        public async Task<CategoriesDetailsResponseModel> DetailsAsync(
            int id)
            => await this.Mapper
                .ProjectTo<CategoriesDetailsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(p => p.Id == id))
                .FirstOrDefaultAsync();

        public Task<CategoriesSearchResponseModel> SearchAsync(CategoriesSearchRequestModel model)
        {
            throw new NotImplementedException();
        }

        //saeed
        //public async Task<CategoriesSearchResponseModel> SearchAsync(
        //    CategoriesSearchRequestModel model)
        //{
        //    var specification = this.GetCategorySpecification(model);

        //    var categories = await this.Mapper
        //        .ProjectTo<CategoriesListingResponseModel>(this
        //            .AllAsNoTracking()
        //            .Where(specification)
        //            .Skip((model.Page - 1) * CategoriesPerPage)
        //            .Take(CategoriesPerPage))
        //        .ToListAsync();

        //    var totalPages = await this.GetTotalPages(model);

        //    return new CategoriesSearchResponseModel
        //    {
        //        Categories = categories,
        //        Page = model.Page,
        //        TotalPages = totalPages
        //    };
        //}

        //private async Task<int> GetTotalPages(
        //    CategoriesSearchRequestModel model)
        //{
        //    var specification = this.GetCategorySpecification(model);

        //    var total = await this
        //        .AllAsNoTracking()
        //        .Where(specification)
        //        .CountAsync();

        //    return (int)Math.Ceiling((double)total / CategoriesPerPage);
        //}


        //private Specification<Category> GetCategorySpecification(
        //    CategoriesSearchRequestModel model)
        //    => new CategoryByNameSpecification(model.Query);

        //
    }
}
