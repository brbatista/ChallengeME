using AutoMapper;
using Negocio.DTOs;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.Pedido, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<StatusPedido, StatusPedidoDto>().ReverseMap();
        }

    }
}
