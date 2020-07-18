using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models;
using Models.ViewModels.Api;

namespace Logic.Profiles.Resolvers
{
    public class IdeaCategoryResolver : IValueResolver<Idea, IdeaViewModel, List<string>>
    {
        public List<string> Resolve(Idea source, IdeaViewModel destination, List<string> destMember, ResolutionContext context)
        {
            return source.IdeaCategoryRelationships.Select(x => x.Category.Name).ToList();
        }
    }
}