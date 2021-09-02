﻿namespace BlazorShop.Models.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class OrdersRequestModel
    {
        [Required]
        public int AddressId { get; set; }

        //saeed
        public string Notes { get; set; }
    }
}