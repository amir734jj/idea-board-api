using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Models.Entities
{
    public class UserNotification
    {
        [Key]
        public int Id { get; set; }
        
        public string Subject { get; set; }
        
        public string Text { get; set; }
        
        public bool Collected { get; set; }
        
        public DateTimeOffset DateTime { get; set; }
        
        [JsonIgnore]
        public User User { get; set; }
    }
}