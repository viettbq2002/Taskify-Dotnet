using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.DTOs.Item;
using Taskify.Domain.Entities;

namespace Taskify.Application.MappingProfile
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<CreateItem, Item>();
            CreateMap<Item, ItemResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null))
                .ReverseMap();
            CreateMap<UpdateItem, Item>();

        }
    }
}
