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
    public class ReportController : Controller
    {
        private readonly IReportService _ReportService;
        private readonly IMapper _mapper;
        
        public ReportController(IReportService ReportService, IMapper mapper)
        {
            _ReportService = ReportService;   
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/[controller]")]
        [Authorize(Roles = "Common")]
        public async Task<List<ReportResource>> GetReportsAsync([FromQuery] int testId)
        {
            var reportResources = await _ReportService.ListReportAsync(testId);
            return reportResources;
        }
    
    }

        
}