using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Test_ASP_Core_Web_Api__1_.Dtos;
using Test_ASP_Core_Web_Api__1_.Models;

namespace Test_ASP_Core_Web_Api__1_.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // source -> Target
            CreateMap<User,UserReadDto>();

            CreateMap<UserCreateDto, User>();

            CreateMap<UserUpdateDto, User>();

        }
    }
}
