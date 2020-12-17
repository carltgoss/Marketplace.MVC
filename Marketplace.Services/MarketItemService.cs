﻿using Marketplace.Data;
using Marketplace.Models;
using Marketplace.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Services
{
    public class MarketItemService
    {
        private readonly Guid _userId;

        public MarketItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMarketItem(MarketItemCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newMarketItem = new MarketItem()
                {
                    Name = model.Name,
                    Category = model.Category,
                    Price = model.Price,
                    Description = model.Description,
                    InventoryCount = model.InventoryCount
                };

                ctx.MarketItems.Add(newMarketItem);
                return ctx.SaveChanges() == 1;
            }
        }

        public MarketItemDetail GetMarketItemDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var marketItem = ctx.MarketItems.Single(m => m.MarketId == id);
                return new MarketItemDetail
                {
                    MarketId = marketItem.MarketId,
                    Name = marketItem.Name,
                    Category = marketItem.Category,
                    Price = marketItem.Price,
                    Description = marketItem.Description,
                    InventoryCount = marketItem.InventoryCount
                };
            }
        }

        public IEnumerable<MarketListItem> GetMarketItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.MarketItems.Select(m => new MarketListItem
                {
                    Name = m.Name,
                    Price = m.Price
                });

                return query.ToArray();
            }
        }

        public bool UpdateMarketItem(MarketItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var marketItem = ctx.MarketItems.Single(m => m.MarketId == model.MarketId);
                marketItem.Name = marketItem.Name;
                marketItem.Category = marketItem.Category;
                marketItem.Price = marketItem.Price;
                marketItem.Description = marketItem.Description;
                marketItem.InventoryCount = marketItem.InventoryCount;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
