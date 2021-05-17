using System.Threading.Tasks;
using AutoMapper;
using Testology_Dotnet.Resources.Auth;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Testology_Dotnet.Controllers.Auth
{
    [ApiController]
    [Route("/api/auth/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<UserCredentialsResource, User>(userCredentials);
            
            var response = await _userService.CreateUserAsync(user, ApplicationRole.Common);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(response.User);
            return Ok(userResource);
        }

        [HttpPost]
        [Route("/api/auth/password/edit")]
        public async Task<IActionResult> UpdateUserPasswordAsync([FromBody] UserUpdateResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<UserUpdateResource, User>(userCredentials);
            
            var response = await _userService.UpdateUserPasswordAsync(user);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(response.User);
            return Ok(userResource);
        }
    }
}