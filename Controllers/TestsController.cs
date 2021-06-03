using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Resources;
using Microsoft.AspNetCore.Authorization;
using Testology_Dotnet.Resources.Auth;

namespace Testology_Dotnet.Controllers
{
    [Route("/api/[controller]")]
    [Authorize(Roles = "Common")]
    public class TestsController : Controller
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;
        
        public TestsController(ITestService testService, IMapper mapper)
        {
            _testService = testService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<TestResource>> GetAllAsync([FromQuery] string userEmail)
        {
            var tests = await _testService.ListAsync(userEmail);
            var resources = _mapper.Map<IEnumerable<Test>, IEnumerable<TestResource>>(tests);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateTestAsync([FromBody] TestResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var test = _mapper.Map<TestResource, Test>(body);
            
            var response = await _testService.CreateOrUpdateTestAsync(test, body.UserEmail);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var testResource = _mapper.Map<Test, TestResource>(response.Test);
            return Ok(testResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteTestAsync([FromQuery] int testId)
        {
            
            var response = await _testService.DeleteTestAsync(testId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}