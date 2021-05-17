using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Resources;

namespace Testology_Dotnet.Controllers
{
    [Route("/api/[controller]")]
    public class TestsController : Controller
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;
        
        public TestsController(ITestService testService, IMapper mapper)
        {
            _testService = testService;   
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TestResource>> GetAllAsync()
        {
            var tests = await _testService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Test>, IEnumerable<TestResource>>(tests);
            return resources;
        }
    }
}