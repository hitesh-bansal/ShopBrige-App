using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBrige_App.DTOs
{
    public class ItemDto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantity can't be greater than 100")]
        public int Quantity { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The Price field must be greater than 0")]
        public decimal Price { get; set; }
    }
}