using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(AppDbContext context) : base(context)
        {
        }
        public void Add(Image image)
        {
            _context.Images.Add(image);
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public void Update(Image image)
        {
            _context.Images.Update(image);
        }
    }
}