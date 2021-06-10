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
    public class AnswersController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        
        public AnswersController(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;   
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateAnswerAsync([FromBody] AnswerResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var answer = _mapper.Map<AnswerResource, Answer>(body);
            
            var response = await _answerService.CreateOrUpdateAnswerAsync(answer);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var answerResource = _mapper.Map<Answer, AnswerResource>(response.Answer);
            return Ok(answerResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteAnswerAsync([FromQuery] int answerId)
        {
            
            var response = await _answerService.DeleteAnswerAsync(answerId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }   
    }
}