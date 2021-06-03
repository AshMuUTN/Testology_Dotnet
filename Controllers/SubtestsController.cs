using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Resources;
using Microsoft.AspNetCore.Authorization;

namespace Testology_Dotnet.Controllers
{
    [Route("/api/[controller]")]
    [Authorize(Roles = "Common")]
    public class SubtestsController : Controller
    {
        private readonly ISubtestService _subtestService;
        private readonly IMapper _mapper;
        
        public SubtestsController(ISubtestService subtestService, IMapper mapper)
        {
            _subtestService = subtestService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<SubtestResource>> GetAllAsync([FromQuery] int testId)
        {
            var subtests = await _subtestService.ListAsync(testId);
            var resources = _mapper.Map<IEnumerable<Subtest>, IEnumerable<SubtestResource>>(subtests);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateSubtestAsync([FromBody] SubtestResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var subtest = _mapper.Map<SubtestResource, Subtest>(body);
            
            var response = await _subtestService.CreateOrUpdateSubtestAsync(subtest);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var subtestResource = _mapper.Map<Subtest, SubtestResource>(response.Subtest);
            return Ok(subtestResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteSubtestAsync([FromQuery] int subtestId)
        {
            
            var response = await _subtestService.DeleteSubtestAsync(subtestId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}