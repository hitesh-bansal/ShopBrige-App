using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBrige_App.DTOs;
using ShopBrige_App.Models;

namespace ShopBrige_App.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<InventoryItem, ItemDto>();
            Mapper.CreateMap<ItemDto, InventoryItem>();
        }
    }
}