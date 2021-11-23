using ShopBrige_App.DTOs;
using ShopBrige_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBrige_App.Services
{
    public interface IItems
    {
        IEnumerable<ItemDto> GetItems();
        ItemDto GetItem(int ID);
        int CreateItem(ItemDto itemDto);
        Task<ItemDto> UpdateItems(int id, ItemDto itemDto);
        Task<ItemDto> DeleteItem(int id);
    }
}