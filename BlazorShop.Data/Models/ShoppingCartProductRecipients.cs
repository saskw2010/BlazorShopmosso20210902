
namespace BlazorShop.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class ShoppingCartProductRecipients: BaseModel
    {
        public int Id { get; set; }

        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string RecipientName { get; set; }

        public int Quantity { get; set; }

        public string Serial { get; set; }
        public string Notes { get; set; }
    }
}
