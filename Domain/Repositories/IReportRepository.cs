using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Resources;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IReportRepository
    {
        Task<List<ReportResource>> ListAsync(int testId);
    }
}