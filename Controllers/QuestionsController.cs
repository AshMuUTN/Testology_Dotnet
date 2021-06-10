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
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        
        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<QuestionResource>> GetAllAsync([FromQuery] int subtestId)
        {
            var questions = await _questionService.ListAsync(subtestId);
            var resources = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionResource>>(questions);
            return resources;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<AnsweredQuestionResource>> GetAnsweredQuestionsAsync([FromQuery] int subtestId, int protocolId)
        {
            var questions = await _questionService.ListAnsweredAsync(subtestId, protocolId);
            var resources = _mapper.Map<IEnumerable<Question>, IEnumerable<AnsweredQuestionResource>>(questions);
            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateQuestionAsync([FromBody] QuestionResourceNoOptions body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var question = _mapper.Map<QuestionResourceNoOptions, Question>(body);
            
            var response = await _questionService.CreateOrUpdateQuestionAsync(question);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var questionResource = _mapper.Map<Question, QuestionResource>(response.Question);
            return Ok(questionResource);
        }

        [HttpPost]
        [Route("/api/[controller]/text")]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateTextQuestionAsync([FromBody] TextQuestionResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var question = _mapper.Map<TextQuestionResource, Question>(body);
            
            var response = await _questionService.CreateOrUpdateQuestionAsync(question);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var questionResource = _mapper.Map<Question, QuestionResource>(response.Question);
            return Ok(questionResource);
        }

        [HttpPost]
        [Route("/api/[controller]/number")]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> CreateOrUpdateNumberQuestionAsync([FromBody] NumberQuestionResource body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var question = _mapper.Map<NumberQuestionResource, Question>(body);
            
            var response = await _questionService.CreateOrUpdateQuestionAsync(question);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            var questionResource = _mapper.Map<Question, QuestionResource>(response.Question);
            return Ok(questionResource);
        }

        [HttpDelete]
        [Authorize(Roles = "Common")]
        public async Task<IActionResult> DeleteQuestionAsync([FromQuery] int questionId)
        {
            
            var response = await _questionService.DeleteQuestionAsync(questionId);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok();
        }
    }
}