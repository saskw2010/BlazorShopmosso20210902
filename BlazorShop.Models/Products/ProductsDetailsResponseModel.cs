namespace BlazorShop.Models.Products
{
    public class ProductsDetailsResponseModel : ProductsListingResponseModel
    {
        public new int Quantity { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
