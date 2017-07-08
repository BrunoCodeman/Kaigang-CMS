using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace kaigang.Models.Entities
{
    public class Post : Model
    {
        
        [Key]
        public Guid ID {get; set;}
        
        [Required]
        public string Title {get; set;}
        
        [Required]
        public string Content {get; set;}

        [Required]
        public bool IsDraft {get; set;}
        
        [Required]
        public DateTime PublishDate {get; set;}
        
        [Required]
        public User Author { get; set; }
        
        [Required]
        public JsonObject<List<string>> Tags { get; set; } 

    }
}