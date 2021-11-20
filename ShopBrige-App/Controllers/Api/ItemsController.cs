﻿using AutoMapper;
using ShopBrige_App.DTOs;
using ShopBrige_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBrige_App.Controllers.Api
{
    public class ItemsController : ApiController
    {
        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/items
        public IEnumerable<ItemDto> GetItems()
        {
            return _context.inventoryItems.ToList().Select(Mapper.Map<InventoryItem, ItemDto>);
        }

        // GET /api/items/1
        public IHttpActionResult GetItem(int id)
        {
            var item = _context.inventoryItems.SingleOrDefault(c => c.ID == id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<InventoryItem, ItemDto>(item));
        }

        // POST /api/item
        [HttpPost]
        public async Task<IHttpActionResult> CreateItem(ItemDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = Mapper.Map<ItemDto, InventoryItem>(itemDto);
            _context.inventoryItems.Add(item);
            await _context.SaveChangesAsync();

            itemDto.ID = item.ID;
            return Created(new Uri(Request.RequestUri + "/" + item.ID), itemDto);
        }

        // PUT /api/items/1
        [HttpPut]
        public async void UpdateItems(int id, ItemDto itemDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var item = _context.inventoryItems.SingleOrDefault(c => c.ID == id);

            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(itemDto, item);

            await _context.SaveChangesAsync();
        }

        // DELETE /api/items/1
        [HttpDelete]
        public async void DeleteItem(int id)
        {
            var customerInDb = _context.inventoryItems.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.inventoryItems.Remove(customerInDb);
            await _context.SaveChangesAsync();
        }
    }
}
