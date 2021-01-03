using System;
using System.Threading.Tasks;
using Logic.Interfaces;
using Models.Interfaces;

namespace Logic.Extensions
{
    public static class BasicCrudExtension
    {
        public static async Task<T> Update<T>(this IBasicLogic<T> logic, int id, Action<T> updater) where T : IEntity
        {
            var entity = await logic.Get(id);

            updater(entity);

            return await logic.Update(id, entity);
        }
    }
}