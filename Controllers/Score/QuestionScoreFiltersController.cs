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
    public class QuestionScoreFiltersController : Controller
    {
        private readonly IQuestionScoreFilterService _questionScoreFilterService;
        private readonly IMapper _mapper;
        
        public QuestionScoreFiltersController(IQuestionScoreFilterService questionScoreFilterService, IMapper mapper)
        {
            _questionScoreFilterService = questionScoreFilterService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<QuestionScoreFilterResource>> GetQuestionFiltersAsync([FromQuery] int questionId)
        {
            var questionScoreFilters = await _questionScoreFilterService.ListAsync(questionId);
            var resources = _mapper.Map<IEnumerable<QuestionScoreFilter>, IEnumerable<QuestionScoreFilterResource>>(questionScoreFilters);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateQuestionScoreFilterAsync([FromBody] QuestionScoreFilterResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var questionScoreFilter = _mapper.Map<QuestionScoreFilterResource, QuestionScoreFilter>(body);
            
            var response = await _questionScoreFilterService.CreateOrUpdateQuestionScoreFilterAsync(questionScoreFilter);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var questionScoreFilterResource = _mapper.Map<QuestionScoreFilter, QuestionScoreFilterResource>(response.QuestionScoreFilter);
            return Ok(questionScoreFilterResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteQuestionScoreFilterAsync([FromQuery] int questionScoreFilterId)
        {
            
            var response = await _questionScoreFilterService.DeleteQuestionScoreFilterAsync(questionScoreFilterId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}