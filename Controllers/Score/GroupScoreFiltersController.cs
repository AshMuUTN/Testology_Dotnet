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
    public class GroupScoreFiltersController : Controller
    {
        private readonly IGroupScoreFilterService _groupScoreFilterService;
        private readonly IMapper _mapper;
        
        public GroupScoreFiltersController(IGroupScoreFilterService groupScoreFilterService, IMapper mapper)
        {
            _groupScoreFilterService = groupScoreFilterService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<GroupScoreFilterResource>> GetGroupFiltersAsync([FromQuery] int groupId)
        {
            var groupScoreFilters = await _groupScoreFilterService.ListAsync(groupId);
            var resources = _mapper.Map<IEnumerable<GroupScoreFilter>, IEnumerable<GroupScoreFilterResource>>(groupScoreFilters);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateGroupScoreFilterAsync([FromBody] GroupScoreFilterResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var groupScoreFilter = _mapper.Map<GroupScoreFilterResource, GroupScoreFilter>(body);
            
            var response = await _groupScoreFilterService.CreateOrUpdateGroupScoreFilterAsync(groupScoreFilter);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var groupScoreFilterResource = _mapper.Map<GroupScoreFilter, GroupScoreFilterResource>(response.GroupScoreFilter);
            return Ok(groupScoreFilterResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteGroupScoreFilterAsync([FromQuery] int groupScoreFilterId)
        {
            
            var response = await _groupScoreFilterService.DeleteGroupScoreFilterAsync(groupScoreFilterId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}