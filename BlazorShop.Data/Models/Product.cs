﻿namespace BlazorShop.Data.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class Product : BaseDeletableModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        //public string Imagebinary { get; set; }

        public int Quantity { get; set; }

        public decimal PriceBeforeDiscount { get; set; }

        public decimal Price { get; set; }

        public string PriceType { get; set; }

        public string ProductCode { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<WishlistProduct> Wishlists { get; } = new HashSet<WishlistProduct>();

        public ICollection<ShoppingCartProduct> ShoppingCarts { get; } = new HashSet<ShoppingCartProduct>();


        public ICollection<OrderProduct> Orders { get; } = new HashSet<OrderProduct>();


        public ICollection<ShoppingCartProductRecipients> ShoppingCartProductRecipients { get; } = new HashSet<ShoppingCartProductRecipients>();

    }
}