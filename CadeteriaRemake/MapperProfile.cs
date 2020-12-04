using AutoMapper;
using CadeteriaRemake.Entidades;
using CadeteriaRemake.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<Pedido, AltaPedidoViewModel>().ReverseMap();
            CreateMap<Pedido, EditarPedidoViewModel>().ReverseMap();
            CreateMap<Cadete, SelectListItem>().ForMember(
                    dest => dest.Text, origen => origen.MapFrom(src => src.Nombre)
                )
                .ForMember(
                    dest => dest.Value, origen => origen.MapFrom(src => src.Id)
                );

            CreateMap<Cliente, SelectListItem>().ForMember(
                    dest => dest.Text, origen => origen.MapFrom(src => src.Nombre)
                )
                .ForMember(
                    dest => dest.Value, origen => origen.MapFrom(src => src.Id)
                );
        }
    }
}
