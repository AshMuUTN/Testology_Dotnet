using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Testology_Dotnet.Resources.Auth;
using System;

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

        [Route("/api/Tests/current_user")]
        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<TestResource>> GetAllAsync([FromBody] UserResource user)
        {
            var tests = await _testService.ListAsync(user.Email);
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
    }
}