namespace BlazorShop.Models.Categories
{
    public class CategoriesDetailsResponseModel : CategoriesListingResponseModel
    {
        

        public new int Id { get; set; }

        public new string Name { get; set; }

        public new string ImageSource { get; set; }
    }
}
