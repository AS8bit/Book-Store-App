﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShoppingCartMVCUI.Models
{
    [Table("OrderStatus")]

    public class OrderStatus
    {
        public int Id { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required, MaxLength(20)]
        public String? StatusName { get; set; }

    }
}
