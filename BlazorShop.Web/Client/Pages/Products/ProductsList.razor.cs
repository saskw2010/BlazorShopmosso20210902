namespace BlazorShop.Web.Client.Pages.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    using Models.Categories;
    using Models.Products;
    using Models.ShoppingCarts;

    public partial class ProductsList
    {
        private readonly ProductsSearchRequestModel model = new ProductsSearchRequestModel();
        public int count=0;

        private ProductsSearchResponseModel searchResponse;
        private IEnumerable<ProductsListingResponseModel> products;
        private IEnumerable<CategoriesListingResponseModel> categories;
        //saeed
        //private readonly ShoppingCartRequestModel model2 = new ShoppingCartRequestModel();
        //private decimal totalPrice;
        //private IEnumerable<ShoppingCartProductsResponseModel> cartProducts;

        //protected override async Task OnInitializedAsync() => await this.LoadDataAsync();

        [Parameter]
        public int? CategoryId { get; set; }

        [Parameter]
        public string CategoryName { get; set; }

        [Parameter]
        public string SearchQuery { get; set; } = string.Empty;

        [Parameter]
        public int Page { get; set; } = 1;

        [Parameter]
        public bool ListView { get; set; } = false;

        [Parameter]
        public bool GridView { get; set; } = true;

        //protected override async Task OnInitializedAsync() => await this.LoadDataAsync();
        protected override async Task OnInitializedAsync() => await this.LoadData();

        protected override async Task OnParametersSetAsync() => await this.LoadData(withCategories: false);

        private async Task SelectedPage(int page)
        {
            this.Page = page;

            await this.LoadData(withCategories: false);
        }

        private async Task LoadData(bool withCategories = true)
        {
            if (this.Page == 0)
            {
                this.Page = 1;
            }

            this.model.Category = this.CategoryId;
            this.model.Query = this.SearchQuery;
            this.model.Page = this.Page;

            this.searchResponse = await this.ProductsService.SearchAsync(this.model);
            this.products = this.searchResponse.Products;
            count = this.products.Count();
            //saeed
            //this.cartProducts = await this.ProductsService.Mine();
            //this.totalPrice = this.cartProducts.Sum(p => p.Price * p.Quantity);
            //this.cartProducts = await this.ProductsService.Mine();
            //this.totalPrice = this.cartProducts.Sum(p => p.Price * p.Quantity);

            if (withCategories)
            {
                this.categories = await this.CategoriesService.All();
            }

            this.Filter();
        }

        private async Task AddToWishlist(int id)
        {
            await this.WishlistsService.AddProduct(id);
            this.NavigationManager.NavigateTo("/wishlist");
        }

        private async Task AddToCart(int id)
        {
            var cartRequest = new ShoppingCartRequestModel
            {
                ProductId = id,
                Quantity = 1
            };

            var result = await this.ShoppingCartsService.AddProduct(cartRequest);

            if (!result.Succeeded)
            {
                //this.ToastService.ShowError(result.Errors.First());
                this.ToastService.ShowError("تم إضافة هذه الهدية من قبل");
            }
            else
            {
                //this.NavigationManager.NavigateTo("/cart", forceLoad: true);
                //this.NavigationManager.NavigateTo("/products/page/1", forceLoad: true);
                this.ToastService.ShowSuccess("تم إضافة الهدية بنجاح");
            }
        }


        //private async Task LoadData()
        //{
        //    this.cartProducts = await this.ProductsService.Mine();
        //    this.totalPrice = this.cartProducts.Sum(p => p.Price * p.Quantity);
        //    //this.cartProducts = await this.ShoppingCartsService.Mine();
        //    //this.totalPrice = 2;
        //}

        //private async Task IncrementQuantity(int productId, int quantity, int stockQuantity)
        //{
        //    this.model2.ProductId = productId;
        //    this.model2.Quantity = quantity;

        //    if (this.model2.Quantity + 1 <= stockQuantity)
        //    {
        //        this.model2.Quantity++;

        //        await this.ShoppingCartsService.UpdateProduct(this.model2);
        //        //await this.LoadData(withCategories: false);
        //    }
        //}

        //private async Task DecrementQuantity(int productId, int quantity)
        //{
        //    this.model2.ProductId = productId;
        //    this.model2.Quantity = quantity;

        //    if (this.model2.Quantity - 1 > 0)
        //    {
        //        this.model2.Quantity--;

        //        await this.ShoppingCartsService.UpdateProduct(this.model2);
        //        //await this.LoadData(withCategories: false);
        //    }
        //}

        private void ChangeView()
        {
            this.ListView = !this.ListView;
            this.GridView = !this.GridView;
        }

        private void Reset()
        {
            this.model.MinPrice = null;
            this.model.MaxPrice = null;
            this.NavigationManager.NavigateTo("/products/page/1");
        }

        private void Filter()
        {
            if (!string.IsNullOrWhiteSpace(this.model.Query) && string.IsNullOrWhiteSpace(this.CategoryName) && !this.model.Category.HasValue)
            {
                this.NavigationManager.NavigateTo($"/products/search/{this.model.Query}/page/{this.model.Page}");
            }
            else if (!string.IsNullOrWhiteSpace(this.model.Query) && !string.IsNullOrWhiteSpace(this.CategoryName) && this.model.Category.HasValue)
            {
                this.NavigationManager.NavigateTo($"/products/category/{this.CategoryName}/{this.model.Category}/search/{this.model.Query}/page/{this.model.Page}");
            }
            else if (!string.IsNullOrWhiteSpace(this.CategoryName) && this.model.Category.HasValue)
            {
                this.NavigationManager.NavigateTo($"/products/category/{this.CategoryName}/{this.model.Category}/page/{this.model.Page}");
            }
            else if (string.IsNullOrWhiteSpace(this.model.Query) && string.IsNullOrWhiteSpace(this.CategoryName) && !this.model.Category.HasValue)
            {
                this.NavigationManager.NavigateTo($"/products/page/{this.model.Page}");
            }
        }
    }
}
