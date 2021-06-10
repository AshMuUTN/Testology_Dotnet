using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Resources;

namespace Testology_Dotnet.Controllers
{
    [Route("/api/[controller]")]
    [Authorize(Roles="Common")]
    public class ProtocolsController : Controller
    {
        private readonly IProtocolService _protocolService;
        private readonly IMapper _mapper;
        
        public ProtocolsController(IProtocolService protocolService, IMapper mapper)
        {
            _protocolService = protocolService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<ProtocolResource>> GetAllAsync([FromQuery] int testId)
        {
            var protocols = await _protocolService.ListAsync(testId);
            var resources = _mapper.Map<IEnumerable<Protocol>, IEnumerable<ProtocolResource>>(protocols);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateProtocolAsync([FromBody] ProtocolResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var protocol = _mapper.Map<ProtocolResource, Protocol>(body);
            
            var response = await _protocolService.CreateOrUpdateProtocolAsync(protocol);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var protocolResource = _mapper.Map<Protocol, ProtocolResource>(response.Protocol);
            return Ok(protocolResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteProtocolAsync([FromQuery] int protocolId)
        {
            
            var response = await _protocolService.DeleteProtocolAsync(protocolId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}