using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ParkerFox.Core.Entities;
using ParkerFox.Infrastructure;
using ParkerFox.Site.ViewModels;

namespace ParkerFox.Site.Component
{
    public class MapViewModelToCommand : IBootStrapTask
    {
        public int Priority
        {
            get { return 2; }
        }

        public void Execute()
        {
            Mapper.CreateMap<ProductViewModel, Product>();
        }
    }
}