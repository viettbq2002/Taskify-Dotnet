using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskify.Application.DTOs.ItemCategory;
using Taskify.Domain.Entities;

namespace Taskify.Application.MappingProfile
{
    public class ItemCategoryProfile: Profile
    {
        public ItemCategoryProfile() {

            CreateMap<CreateItemCategory, ItemCateogry>().ReverseMap();
            CreateMap<UpdateItemCategory, ItemCateogry>().ReverseMap();
            CreateMap<ItemCategoryResponse, ItemCateogry>().ReverseMap();
        }
    }
}
