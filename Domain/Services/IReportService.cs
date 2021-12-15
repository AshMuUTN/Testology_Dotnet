using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Resources;

namespace Testology_Dotnet.Domain.Services
{
    public interface IReportService
    {
        Task<List<ReportResource>> ListReportAsync(int protocolId);
    }
}