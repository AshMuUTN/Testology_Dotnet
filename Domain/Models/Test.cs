using System;
using System.Collections.Generic;

namespace Testology_Dotnet.Domain.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}