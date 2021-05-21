using System;
using System.ComponentModel.DataAnnotations;

namespace Testology_Dotnet.Resources
{
    public class TestResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string UserEmail { get; set; }
        public int UserId { get; set; }
         
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime Created_at { get; set; }

    }
}