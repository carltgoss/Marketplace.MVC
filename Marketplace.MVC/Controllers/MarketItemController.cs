using Marketplace.Models;
using Marketplace.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketplace.MVC.Controllers
{
    public class MarketItemController : Controller
    {
        // GET: MarketItem
        public ActionResult Index()
        {
            return View(CreateMarketItemService().GetMarketItems());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Market Item";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarketItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateMarketItemService().CreateMarketItem(model))
            {
                TempData["SaveResult"] = "Market Item Established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error in creating market item");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var marketItem = CreateMarketItemService().GetMarketItemDetailById(id);
            return View(marketItem);
        }

        public ActionResult Edit(int id)
        {
            var marketItem = CreateMarketItemService().GetMarketItemDetailById(id);
            return View(new MarketItemEdit
            {
                MarketId = marketItem.MarketId,
                Name = marketItem.Name,
                Category = marketItem.Category,
                Price = marketItem.Price,
                Description = marketItem.Description,
                InventoryCount = marketItem.InventoryCount
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MarketItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MarketId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateMarketItemService().UpdateMarketItem(model))
            {
                TempData["SaveResult"] = "Market Item Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error in creating market item");
            return View(model);
        }

        private MarketItemService CreateMarketItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MarketItemService(userId);
            return service;
        }
    }
}