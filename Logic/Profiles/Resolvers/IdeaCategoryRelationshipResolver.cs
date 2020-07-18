using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EfCoreRepository.Interfaces;
using Models;
using Models.Relationships;
using Models.ViewModels.Api;

namespace Logic.Profiles.Resolvers
{
    public class IdeaCategoryRelationshipResolver : IValueResolver<IdeaViewModel, Idea, List<IdeaCategoryRelationship>>
    {
        private readonly IBasicCrudType<IdeaCategoryRelationship, int> _ideaCategoryRelationshipDal;

        public IdeaCategoryRelationshipResolver(IEfRepository efRepository)
        {
            _ideaCategoryRelationshipDal =  efRepository.For<IdeaCategoryRelationship, int>();
        }

        public List<IdeaCategoryRelationship> Resolve(IdeaViewModel source, Idea destination, List<IdeaCategoryRelationship> destMember, ResolutionContext context)
        {
            return _ideaCategoryRelationshipDal.GetAll().Result
                .Join(source.Categories, x => x.Category.Name, x => x, (relationship, _) => relationship)
                .ToList();
        }
    }
}