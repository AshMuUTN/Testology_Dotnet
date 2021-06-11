using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class ProtocolRepository : BaseRepository, IProtocolRepository
    {
        public ProtocolRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(Protocol protocol)
        {
            _context.Protocols.Add(protocol);
        }

        public async Task Delete(int protocolId)
        {
            var protocol = await _context.Protocols.Where(s => s.Id == protocolId).FirstOrDefaultAsync();
            protocol.DeletedAt = System.DateTime.Now;

            _context.Protocols.Attach(protocol);
            _context.Entry(protocol).Property(s => s.DeletedAt).IsModified = true;
        }

        public Task<IEnumerable<Protocol>> ListAsync(int testId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Protocol protocol)
        {
            _context.Protocols.Update(protocol);
        }
    }
}