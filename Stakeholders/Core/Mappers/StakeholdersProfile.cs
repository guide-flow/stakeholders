using AutoMapper;
using Core.Domain;
using API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
    public class StakeholdersProfile:Profile
    {
        public StakeholdersProfile() 
        {
            CreateMap<UserProfile,UserProfileDto>().ReverseMap();
        }
    }
}
