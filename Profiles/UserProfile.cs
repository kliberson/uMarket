using AutoMapper;
using uMarket.ViewModels;
using uMarket.Models;

namespace uMarket.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
