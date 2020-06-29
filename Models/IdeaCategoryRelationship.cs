using Models.Interfaces;

namespace Models
{
    public class IdeaCategoryRelationship : IEntity
    {
        public int Id { get; set; }
        
        public int IdeaId { get; set; }
        
        public int CategoryId { get; set; }
        
        public Idea Idea { get; set; }
        
        public Category Category { get; set; }
    }
}