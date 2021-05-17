using System.Threading.Tasks;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}