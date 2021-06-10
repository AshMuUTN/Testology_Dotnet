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
    public class DivisionsController : Controller
    {
        private readonly IDivisionService _divisionService;
        private readonly IMapper _mapper;
        
        public DivisionsController(IDivisionService divisionService, IMapper mapper)
        {
            _divisionService = divisionService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<DivisionResource>> GetAllAsync([FromQuery] int subtestId)
        {
            var divisions = await _divisionService.ListAsync(subtestId);
            var resources = _mapper.Map<IEnumerable<Division>, IEnumerable<DivisionResource>>(divisions);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateDivisionAsync([FromBody] DivisionResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var division = _mapper.Map<DivisionResource, Division>(body);
            
            var response = await _divisionService.CreateOrUpdateDivisionAsync(division);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var divisionResource = _mapper.Map<Division, DivisionResource>(response.Division);
            return Ok(divisionResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteDivisionAsync([FromQuery] int divisionId)
        {
            
            var response = await _divisionService.DeleteDivisionAsync(divisionId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}