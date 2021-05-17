using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Testology_Dotnet.Controllers.Auth
{
    [ApiController]
    public class ProtectedController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("/api/protectedforcommonusers")]
        public IActionResult GetProtectedData()
        {
            return Ok("Hello world from protected controller.");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("/api/protectedforadministrators")]
        public IActionResult GetProtectedDataForAdmin()
        {
            return Ok("Hello admin!");
        }
    }
}