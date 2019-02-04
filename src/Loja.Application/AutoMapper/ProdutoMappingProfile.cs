using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.AutoMapper
{
    public class ProdutoMappingProfile : Profile
    {
        public ProdutoMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
