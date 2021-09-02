namespace BlazorShop.Data.Seed
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class CategoriesData : IInitialData
    {
        public Type EntityType => typeof(Category);

        public IEnumerable<object> GetData()
            => new List<Category>
            {
                //new Category { Name = "Fashion",ImageSource = "https://gorilla.bg/userfiles/productlargeimages/product_256.jpg" },
                //new Category { Name = "Electronics",ImageSource = "https://static.plasico.bg/thumbs/12/mwvf2bsa.jpg" },
                //new Category { Name = "Books, Movies & Music",ImageSource = "https://www.augoods.com.au/assets/full/DVD-LN-9322225226746.jpg?20200703062244" }
            };
    }
}
