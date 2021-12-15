using System.Collections.Generic;

namespace Testology_Dotnet.Resources
{
    public class ReportResource
    {
        public List<ReportSubtest> Subtests { get; set; }
        public ProtocolResource Protocol { get; set; }
        public float Total { get; set; }
        public float Percentage { get; set; }
    }
}