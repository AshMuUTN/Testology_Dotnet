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
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        
        public GroupsController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<GroupResource>> GetAllAsync([FromQuery] int subtestId)
        {
            var groups = await _groupService.ListAsync(subtestId);
            var resources = _mapper.Map<IEnumerable<Group>, IEnumerable<GroupResource>>(groups);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateGroupAsync([FromBody] GroupResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var group = _mapper.Map<GroupResource, Group>(body);
            
            var response = await _groupService.CreateOrUpdateGroupAsync(group);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var groupResource = _mapper.Map<Group, GroupResource>(response.Group);
            return Ok(groupResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteGroupAsync([FromQuery] int groupId)
        {
            
            var response = await _groupService.DeleteGroupAsync(groupId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}