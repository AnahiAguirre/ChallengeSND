using AutoMapper;
using ChallengeSND.Business.DTOS;
using ChallengeSND.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSND.Business.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<ApplicationUser, LoginDTO>();
            CreateMap<ApplicationUser, RegisterDTO>();
        }
    }
}
