using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ASPPatterns.Chap8.AutoMapper.Model;
using ASPPatterns.Chap8.AutoMapper.AppService.Views;

namespace ASPPatterns.Chap8.AutoMapper.AppService
{
    public class BootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Order, OrderView>();
            Mapper.CreateMap<Item, ItemView>();
        }
    }
}
