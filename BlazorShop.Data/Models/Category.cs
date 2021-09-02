namespace BlazorShop.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class Category : BaseDeletableModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public string ImageBinary { get; set; }

        public string Imagepic { get; set; }

        //public string Imagebinary { get; set; }

        public ICollection<Product> Products { get; } = new HashSet<Product>();
    }
}