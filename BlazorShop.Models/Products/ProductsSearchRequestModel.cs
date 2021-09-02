

namespace BlazorShop.Models.Products
{
    //saeed
    using System.ComponentModel.DataAnnotations;
    using static Data.ModelConstants.Product;
    //
    public class ProductsSearchRequestModel
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
