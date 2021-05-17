using AutoMapper;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Resources;
using Testology_Dotnet.Resources.Auth;

namespace Testology_Dotnet.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<TestResource, Test>();
            CreateMap<UserCredentialsResource, User>();
            CreateMap<UserUpdateResource, User>();
        }
    }
}