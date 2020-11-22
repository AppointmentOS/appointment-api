using AutoMapper;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Api.DTOs
{
    public class BusinessUserDetailDto : Mapper.IMapFrom<BusinessUser>
    {
        public string Id { get; set; }
        public string BusinessName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BusinessUser, BusinessUserDetailDto>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id.ToString()));
        }
    }
}
