using Models.Enums;
using Models.Interfaces;

namespace Models
{
    public class UserVote : IEntity
    {
        public int Id { get; set; }
        
        public Vote Value { get; set; }
        
        public Idea Idea { get; set; }
        
        public int IdeaId { get; set; }
        
        public User User { get; set; }
        
        public int UserId { get; set; }
    }
}