namespace BlazorShop.Data.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class ShoppingCartProduct : BaseModel
    {
        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }

        //public ICollection<ShoppingCartProductRecipients> ProductRecipients { get; } = new HashSet<ShoppingCartProductRecipients>();
    }
}
