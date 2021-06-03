using System;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class SubtestResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public int TestId { get; set; }
        public bool IsScorable { get; set; } = false;
        public bool IsCalculable { get; set; } = false;
         
        [StringLength(3000)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}