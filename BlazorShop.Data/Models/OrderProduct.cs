namespace BlazorShop.Data.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OrderProduct : BaseModel
    {
        public int OrdersProductId { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }

       public virtual List<OrdersProductRecipientsmosso> OrdersProductRecipientsmosso { get; set; }

    }
}
