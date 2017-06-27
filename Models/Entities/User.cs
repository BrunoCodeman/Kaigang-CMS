using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaigang.Models.Entities
{
    public class User
    {
        [Required]
        [Key]
        public Guid ID { get; set; }

        public string Name  { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email  { get; set; }

        [Required]
        public string Password  { get; set; }

        public IEnumerable<Post> Posts {get; set;}
    }
}