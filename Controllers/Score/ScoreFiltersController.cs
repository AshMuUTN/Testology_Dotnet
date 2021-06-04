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
    public class ScoreFiltersController : Controller
    {
        private readonly IScoreFilterService _scoreFilterService;
        private readonly IMapper _mapper;
        
        public ScoreFiltersController(IScoreFilterService scoreFilterService, IMapper mapper)
        {
            _scoreFilterService = scoreFilterService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Common")]
        public async Task<IEnumerable<ScoreFilterResource>> GetAllAsync()
        {
            var scoreFilters = await _scoreFilterService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ScoreFilter>, IEnumerable<ScoreFilterResource>>(scoreFilters);
            return resources;
        }
        
    }
}