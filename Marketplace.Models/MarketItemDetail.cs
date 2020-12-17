using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class MarketItemDetail
    {
        public int MarketId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }      
        public int Price { get; set; }              
        public string Description { get; set; }     
        public int InventoryCount { get; set; }
    }
}
