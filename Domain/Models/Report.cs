using System.Collections.Generic;

namespace Testology_Dotnet.Domain.Models
{
    public class Report
    {
        public List<Subtest> Subtests { get; set; }
        public Protocol Protocol { get; set; }
        
    }
}