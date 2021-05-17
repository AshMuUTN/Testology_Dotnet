using System.Linq;
using AutoMapper;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Resources;
using Testology_Dotnet.Resources.Auth;
using Testology_Dotnet.Domain.Security.Tokens;


namespace Testology_Dotnet.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Test, TestResource>();
            CreateMap<User, UserResource>()
                .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(ur => ur.Role.Name)));

            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
        }
        
    }
}