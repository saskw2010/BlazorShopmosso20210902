

namespace BlazorShop.Models.Categories
{
    //saeed
    using System.ComponentModel.DataAnnotations;
    using static Data.ModelConstants.Category;
    //
    public class CategoriesSearchRequestModel
    {
        public string Query { get; set; }

        public int? Category { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int Page { get; set; } = 1;

        //saeed
        //[Required]
        //public int ProductId { get; set; }

        //[Range(MinQuantity, MaxQuantity)]
        //public int Quantity { get; set; } = MinQuantity;
        //
    }
}
