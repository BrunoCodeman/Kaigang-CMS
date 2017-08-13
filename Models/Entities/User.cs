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

        public IEnumerable<Post> Posts {get; set;}
<<<<<<< HEAD

        public IEnumerable<Comment> Comments {get; set;}
=======
>>>>>>> 6f95a84deafe7d06a3321b118e8898536ea9454c
    }
}