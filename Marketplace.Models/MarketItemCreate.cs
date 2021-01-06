using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class MarketItemCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [MaxLength(8000)]
        public string Description { get; set; }
        [Required]
        public int InventoryCount { get; set; }
    }
}
