using AutoMapper;
using Client.Domain;
using Client.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Mapper
{
    public class ClienteMapper
    {
        private readonly IMapper _mapper;

        public ClienteMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteDTO, Cliente>().ForMember(dest => dest.ImagenBase64, opt => opt.MapFrom(src => Convert.FromBase64String(src.ImagenBase64)));
                cfg.CreateMap<Cliente, ClienteDTO>().ForMember(dest => dest.ImagenBase64, opt => opt.MapFrom(src => Convert.ToBase64String(src.ImagenBase64)));
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        public ClienteDTO MapToDto(Cliente entity)
        {
            return _mapper.Map<ClienteDTO>(entity);
        }

        public Cliente MapToEntity(ClienteDTO dto)
        {
            return _mapper.Map<Cliente>(dto);
        }

        public List<ClienteDTO> MapListToDto(List<Cliente> entityList)
        {
            return _mapper.Map<List<ClienteDTO>>(entityList);
        }

        public List<Cliente> MapListToEntity(List<ClienteDTO> dtoList)
        {
            return _mapper.Map<List<Cliente>>(dtoList);
        }
    }
}
