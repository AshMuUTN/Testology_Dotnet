using System.Collections.Generic;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Domain.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> ListAsync();
         void Add(Image image);
         void Update(Image image);        
    }
}