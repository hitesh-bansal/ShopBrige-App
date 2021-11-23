using AutoMapper;
using ShopBrige_App.DTOs;
using ShopBrige_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBrige_App.Services
{
    public class ItemServices : IItems
    {
        private ApplicationDbContext _context;
        public ItemServices()
        {
            _context = new ApplicationDbContext();
        }
        public int CreateItem(ItemDto itemDto)
        {
            var item = Mapper.Map<ItemDto, InventoryItem>(itemDto);
            _context.inventoryItems.Add(item);
            _context.SaveChanges();

            return item.ID;
        }

        public async Task<ItemDto> DeleteItem(int id)
        {
            var itemInDb = _context.inventoryItems.SingleOrDefault(c => c.ID == id);
            if (itemInDb == null)
                return null;
            _context.inventoryItems.Remove(itemInDb);
            await _context.SaveChangesAsync();
            return Mapper.Map<InventoryItem,ItemDto>(itemInDb);
        }

        public ItemDto GetItem(int ID)
        {
            return Mapper.Map<InventoryItem,ItemDto>(_context.inventoryItems.SingleOrDefault(c => c.ID == ID));
        }

        public IEnumerable<ItemDto> GetItems()
        {
            return _context.inventoryItems.ToList().Select(Mapper.Map<InventoryItem, ItemDto>);
        }

        public async Task<ItemDto> UpdateItems(int id, ItemDto itemDto)
        {
            var item = _context.inventoryItems.SingleOrDefault(c => c.ID == id);
            if (item == null)
                return null;
            Mapper.Map(itemDto, item);
            await _context.SaveChangesAsync();
            return Mapper.Map<InventoryItem,ItemDto>(item);
        }
    }

}