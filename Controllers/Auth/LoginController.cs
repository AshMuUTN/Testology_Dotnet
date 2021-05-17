using SendGrid;
using System.Threading.Tasks;
using AutoMapper;
using Testology_Dotnet.Resources.Auth;
using Testology_Dotnet.Domain.Security.Tokens;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;

namespace Testology_Dotnet.Controllers.Auth
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        private readonly IPasswordRecoveryEmailService _passwordRecoveryEmailService;

        public AuthController(IMapper mapper, IAuthenticationService authenticationService, IPasswordRecoveryEmailService passwordRecoveryEmailService)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _passwordRecoveryEmailService = passwordRecoveryEmailService;
        }

        [Route("/api/auth/login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.CreateAccessTokenAsync(userCredentials.Email, userCredentials.Password);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var accessTokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(accessTokenResource);
        }

        [Route("/api/auth/password_change/request")]
        [HttpPost]
        public async Task<IActionResult> RequestPasswordChangeAsync([FromBody] UserPasswordRecoveryResource userCredentials)
        {

            var response = await _passwordRecoveryEmailService.Execute(userCredentials.Email);
            if(!response.IsSuccessStatusCode){
                if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized){
                    return Unauthorized(new MessageResponse(false,"email no registrado"));
                }
                return BadRequest(new MessageResponse(false,"error al enviar mail"));
            } 
            return Ok(new MessageResponse(true,"email enviado"));
        }

        [Route("/api/auth/token/revoke")]
        [HttpPost]
        public IActionResult RevokeToken([FromBody] RevokeTokenResource revokeTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authenticationService.RevokeRefreshToken(revokeTokenResource.Token);
            return NoContent();
        }

        [Route("/api/auth/token/refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenResource refreshTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.RefreshTokenAsync(refreshTokenResource.Token, refreshTokenResource.UserEmail);
            if(!response.Success)
            {
                return BadRequest(response);
            }
           
            var tokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(tokenResource);
        }
    }
}