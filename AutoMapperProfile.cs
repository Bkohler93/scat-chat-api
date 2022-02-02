using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using scat_chat_api.Models;
using scat_chat_api.Dtos.Scat;

namespace scat_chat_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Scat, GetScatDto>(); 
           CreateMap<Scat, AddScatDto>();
            CreateMap<AddScatDto, Scat>();
        }
    
    }
}