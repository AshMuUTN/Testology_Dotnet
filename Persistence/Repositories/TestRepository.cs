using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Test>> ListAsync(int UserId)
        {
            return await _context.Tests.Where(t => t.UserId == UserId && t.DeletedAt == null).ToListAsync();
        }

        public void Add(Test test)
        {    
            _context.Tests.Add(test);
        }

        public void Update(Test test)
        {    
            _context.Tests.Update(test);
        }

        public async Task Delete(int testId)
        {
            var test = await _context.Tests.Where(t => t.Id == testId).FirstOrDefaultAsync();
            test.DeletedAt = System.DateTime.Now;

            _context.Tests.Attach(test);
            _context.Entry(test).Property(t => t.DeletedAt).IsModified = true;
        }
    }
}