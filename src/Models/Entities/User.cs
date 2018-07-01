using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaigang.Models.Entities
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
        public IEnumerable<Comment> Comments {get; set;}
<<<<<<< HEAD:src/Models/Entities/User.cs
=======
        public IEnumerable<Poll> Polls {get; set;}
>>>>>>> a949f48c0317e7c81eb7b165a1250c8ef2340288:Models/Entities/User.cs
    }
}