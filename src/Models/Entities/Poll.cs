using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kaigang.Models.Entities
{
    public class Poll
    {
        public Poll()
        {
            
        }
        [Key]
        [Required]
        public Guid ID {get; set;}
        
        [Required]
        public User OwnedBy {get; set;}
        
        [Required]
        public string Title {get; set;}

        public DateTime CreatedDate {get; set;}

        public DateTime StartDate {get;set;}

        public DateTime EndDate {get;set;}

        public JsonObject<IDictionary<string, int>> Options {get; set;}

        //Should it be and IQueryable<User>?
        public List<User> Voters{get; set;}
        
    }
}