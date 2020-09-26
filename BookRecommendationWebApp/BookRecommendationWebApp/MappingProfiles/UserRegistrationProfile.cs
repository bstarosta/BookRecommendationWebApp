using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRecommendationWebApp.Models.Accounts;

namespace BookRecommendationWebApp.MappingProfiles
{
    public class UserRegistrationProfile : Profile
    {
        public UserRegistrationProfile()
        {
            CreateMap<UserRegistrationModel, User>();
        }
    }
}
