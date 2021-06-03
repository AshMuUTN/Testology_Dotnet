using System;
using Testology_Dotnet.Domain.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Testology_Dotnet.Domain.Models
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Subtest> Subtests { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}