using ShopBrige_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBrige_App.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Items/Random
        public ActionResult Random()
        {
            var item = new InventoryItem() { Name = "Clothes" };
            return View(item);
        }

        // Add New Item
        [Authorize(Roles = "CanManageItem")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryItem itemModel)
        {
            if(itemModel.ID == 0)
                _context.inventoryItems.Add(itemModel);
            else
            {
               var itemInDB = _context.inventoryItems.SingleOrDefault(i => i.ID == itemModel.ID);
                itemInDB.Name = itemModel.Name;
                itemInDB.Description = itemModel.Description;   
                itemInDB.Quantity = itemModel.Quantity;
                itemInDB.Price = itemModel.Price;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Items");
        }
        // GET: Items
        public ViewResult Index()
        {
            if(User.IsInRole("CanManageItem"))
                return View("Index");
            return View("ReadOnlyItem");
        }

        public ActionResult Edit(int id)
        {
            var item = _context.inventoryItems.SingleOrDefault(i => i.ID == id);
            if (item == null)
                return HttpNotFound();

            return View("New", item); 
        }

        public ActionResult Details(int id)
        {
            var item = _context.inventoryItems.SingleOrDefault(i => i.ID == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

    }
}