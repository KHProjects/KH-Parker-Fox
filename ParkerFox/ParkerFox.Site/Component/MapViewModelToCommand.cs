using AutoMapper;
using ParkerFox.Application.Commands.Publication;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Infrastructure;
using ParkerFox.Site.ViewModels.Ecommerce;
using ParkerFox.Site.ViewModels.Publication;

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
            Mapper.CreateMap<Subscribe, CreateNewSubscription>();
        }
    }
}