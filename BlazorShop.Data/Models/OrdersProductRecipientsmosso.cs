using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorShop.Data.Models
{
    public class OrdersProductRecipientsmosso
    {
        [Key]
        public int Id { get; set; }
       
        public string RecipientName { get; set; }
        public string Quantity { get; set; }
        public string OrderId { get; set; }
        //public Order Order { get; set; }
        //public int ProductId { get; set; }
        //public Product Product { get; set; }
        //[ForeignKey("OrdersProduct")]
        public int OrdersProductId { get; set; }
        public OrderProduct OrderProduct { get; set; }
    }
}
