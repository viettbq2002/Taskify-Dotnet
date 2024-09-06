using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.DTOs.Item;
using Taskify.Application.DTOs.SubItem;
using Taskify.Domain.Entities;

namespace Taskify.Application.MappingProfile
{
    public class SubItemProfile : Profile
    {
        public SubItemProfile()
        {
            CreateMap<Item, ItemResponse>().ReverseMap();
            CreateMap<SubItem,SubItemResponse>().ReverseMap();
        }
    }
}
