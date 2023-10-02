using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TableandCommandControl.DTO;
using TableandCommandControl.Entity;

namespace TableandCommandControl.Mapeamentos
{
    public class Mapeamentos : Profile
    {
     public Mapeamentos()
     {
        // CreateMap<Cliente ,ClientesDtos>();
        //   CreateMap<Mesa ,MesaDtos>();
         // CreateMap<Produtos,ProdutosDtos>();
        //  CreateMap<List<Produtos>, List<ProdutosDtos>>();
      //  CreateMap<Produtos, ProdutosDtos>()
    // .ForMember(dest => dest.id, opt => opt.Ignore())
    // .ForMember(dest => dest.descricao, opt => opt.MapFrom(src => src.descricao))
    // .ForMember(dest=> dest.valorVenda, opt=> opt.MapFrom(src=> src.valorVenda))
    ;

     }
    }
}