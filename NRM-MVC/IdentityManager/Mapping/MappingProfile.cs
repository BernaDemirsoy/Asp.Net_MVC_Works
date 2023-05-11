using AutoMapper;
using IdentityManager.Models;

namespace IdentityManager.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserVM, AppUser>().ReverseMap();
        }
    }
}
