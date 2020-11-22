using AutoMapper;
using Bookeasy.Application.Common.Mappings;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Application.Users.Queries.GetUserDetail
{
    public class UserDto : IMapFrom<BusinessUser>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BusinessUser, UserDto>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id.ToString()));
            profile.CreateMap<UserDto, BusinessUser>();
        }
    }
}
