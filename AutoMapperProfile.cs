using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using scat_chat_api.Models;
using scat_chat_api.Dtos.Post;

namespace scat_chat_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Post, GetPostDto>(); 
           CreateMap<Post, AddPostDto>();
            CreateMap<AddPostDto, Post>();
        }
    
    }
}