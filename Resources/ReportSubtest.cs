using System;
using System.Collections.Generic;

namespace Testology_Dotnet.Resources
{
    public class ReportSubtest
    {
        public IEnumerable<ReportAnsweredQuestion> Questions { get; set; }
        public float Score { get; set; }
        public int Percentage { get; set; }
        public string Name { get; set; }
        public bool IsScorable { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}