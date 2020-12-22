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
        }
    }
}