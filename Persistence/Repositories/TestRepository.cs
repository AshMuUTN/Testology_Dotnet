using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Test>> ListAsync()
        {
            return await _context.Tests.ToListAsync();
        }
    }
}