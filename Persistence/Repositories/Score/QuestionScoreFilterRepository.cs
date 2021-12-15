using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories.Score
{
    public class QuestionScoreFilterRepository : BaseRepository, IQuestionScoreFilterRepository
    {
        public QuestionScoreFilterRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(QuestionScoreFilter questionScoreFilter)
        {
            _context.QuestionScoreFilters.Add(questionScoreFilter);
        }

        public async Task Delete(int questionScoreFilterId)
        {
            var questionScoreFilter = await _context.QuestionScoreFilters.Where(qsf => qsf.Id == questionScoreFilterId).FirstOrDefaultAsync();
            questionScoreFilter.DeletedAt = System.DateTime.Now;

            _context.QuestionScoreFilters.Attach(questionScoreFilter);
            _context.Entry(questionScoreFilter).Property(t => t.DeletedAt).IsModified = true;
        }

        public async Task<IEnumerable<QuestionScoreFilter>> ListAsync(int questionId)
        {
            return await _context.QuestionScoreFilters
                .Where(f => f.QuestionId == questionId && f.DeletedAt == null)
                .OrderBy(f => f.Rank)
                .ToListAsync();
        }

        public void Update(QuestionScoreFilter questionScoreFilter)
        {
            _context.QuestionScoreFilters.Update(questionScoreFilter);
        }

    }
}