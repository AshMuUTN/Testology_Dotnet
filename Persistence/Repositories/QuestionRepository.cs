using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Question>> ListAsync(int subtestId)
        {
            return await _context.Questions
                .Where(s => s.SubtestId == subtestId && s.DeletedAt == null)
                .Include(q => q.Options.Where(o => !o.Deleted))
                .Include(q => q.Image)
                .ToListAsync();
        }
        public void Add(Question question)
        {
            _context.Questions.Add(question);
        }

        public void Update(Question question)
        {
            _context.Questions.Update(question);
        }

        public async Task Delete(int questionId)
        {
            var question = await _context.Questions.Where(q => q.Id == questionId).FirstOrDefaultAsync();
            question.DeletedAt = System.DateTime.Now;

            _context.Questions.Attach(question);
            _context.Entry(question).Property(q => q.DeletedAt).IsModified = true;
        }
    }
}