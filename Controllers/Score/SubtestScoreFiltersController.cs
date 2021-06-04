using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Services.Score;
using Testology_Dotnet.Resources.Score;

namespace Testology_Dotnet.Controllers.Score
{
    [Route("/api/[controller]")]
    [Authorize(Roles = "Common")]
    public class SubtestScoreFiltersController : Controller
    {
        private readonly ISubtestScoreFilterService _subtestScoreFilterService;
        private readonly IMapper _mapper;
        
        public SubtestScoreFiltersController(ISubtestScoreFilterService subtestScoreFilterService, IMapper mapper)
        {
            _subtestScoreFilterService = subtestScoreFilterService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<SubtestScoreFilterResource>> GetAllAsync()
        {
            var subtestScoreFilters = await _subtestScoreFilterService.ListAsync();
            var resources = _mapper.Map<IEnumerable<SubtestScoreFilter>, IEnumerable<SubtestScoreFilterResource>>(subtestScoreFilters);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateSubtestScoreFilterAsync([FromBody] SubtestScoreFilterResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var subtestScoreFilter = _mapper.Map<SubtestScoreFilterResource, SubtestScoreFilter>(body);
            
            var response = await _subtestScoreFilterService.CreateOrUpdateSubtestScoreFilterAsync(subtestScoreFilter);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var subtestScoreFilterResource = _mapper.Map<SubtestScoreFilter, SubtestScoreFilterResource>(response.SubtestScoreFilter);
            return Ok(subtestScoreFilterResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteSubtestScoreFilterAsync([FromQuery] int subtestScoreFilterId)
        {
            
            var response = await _subtestScoreFilterService.DeleteSubtestScoreFilterAsync(subtestScoreFilterId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}