using System;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class ProtocolResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public int TestId { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}