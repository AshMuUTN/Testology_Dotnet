using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class AnswerRepository : BaseRepository, IAnswerRepository
    {
        public AnswerRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(Answer answer)
        {
            _context.Answers.Add(answer);
        }

        public async Task Delete(int answerId)
        {
            var answer = await _context.Subtests.Where(s => s.Id == answerId).FirstOrDefaultAsync();
            answer.DeletedAt = System.DateTime.Now;

            _context.Subtests.Attach(answer);
            _context.Entry(answer).Property(s => s.DeletedAt).IsModified = true;
        }

        public void Update(Answer answer)
        {
            _context.Answers.Update(answer);
        }
    }
}