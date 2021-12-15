using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Resources;

namespace Testology_Dotnet.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IReportRepository reportRepository, IUnitOfWork unitOfWork)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ReportResource>> ListReportAsync(int testId)
        {
            return await _reportRepository.ListAsync(testId);
        }
    }
}