using System;
using AutoMapper;
using minimalApi.Model;
using minimalApi.Model.DTO;

namespace minimalApi
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
		{
			CreateMap<Pizza, PizzaCreatedDTO>().ReverseMap();
            CreateMap<Pizza, PizzaDTO>().ReverseMap();
        }
    }
}

