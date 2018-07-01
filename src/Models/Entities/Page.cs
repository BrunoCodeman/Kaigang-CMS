using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaigang.Models.Entities
{
    public class Page : Model
    {
        [Key]
        [Required]
        public Guid ID {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Content {get;set;}

    }
}