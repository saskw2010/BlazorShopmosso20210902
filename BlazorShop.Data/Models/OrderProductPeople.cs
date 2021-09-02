namespace BlazorShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class OrderProductPeople : BaseModel
    {
        public string OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Name { get; set; }
    }
}
