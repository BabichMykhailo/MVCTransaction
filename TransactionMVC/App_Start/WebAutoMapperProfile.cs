using AutoMapper;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionMVC.Models;

namespace TransactionMVC.App_Start
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<CategoryBLModel, CategoryModel>();
            CreateMap<CategoryBLModel, CategoryModel>().ReverseMap();

            CreateMap<TransactionBLModel, TransactionModel>();
            CreateMap<TransactionBLModel, TransactionModel>().ReverseMap();

            CreateMap<CategoryBLModel, AutoCompleteModel>()
                .ForMember(x => x.data, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.value, opt => opt.MapFrom(src => src.Title));
        }
    }
}