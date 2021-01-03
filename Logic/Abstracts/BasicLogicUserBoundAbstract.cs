using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreRepository.Interfaces;
using Logic.Interfaces;
using Models.Entities;
using Models.Interfaces;

namespace Logic.Abstracts
{
    public abstract class BasicLogicUserBoundAbstract<T> : BasicLogicAbstract<T>, IBasicLogicUserBound<T> where T: class, IEntity, IEntityUserProp
    {
        public IBasicLogic<T> For(User user)
        {
            return new BasicLogicUserBoundImpl<T>(user, GetBasicCrudDal());
        }
    }

    public class BasicLogicUserBoundImpl<T> : BasicLogicAbstract<T> where T: class, IEntity, IEntityUserProp, IEntity<int>
    {
        private readonly User _user;
        
        private readonly IBasicCrudWrapper<T> _basicCrudDal;

        public BasicLogicUserBoundImpl(User user, IBasicCrudWrapper<T> basicCrudDal)
        {
            _user = user;
            _basicCrudDal = basicCrudDal;
        }

        public override Task<T> Save(T instance)
        {
            instance.User = _user;

            return GetBasicCrudDal().Save(instance);
        }

        protected override IBasicCrudWrapper<T> GetBasicCrudDal()
        {
            return _basicCrudDal;
        }

        public override Task<T> Get(int id)
        {
            return GetBasicCrudDal().Get(x => x.User.Id == _user.Id && x.Id == id);
        }

        public override Task<T> Update(int id, T dto)
        {
            dto.User = _user;

            return GetBasicCrudDal().Update(x => x.User.Id == _user.Id && x.Id == id, dto);
        }

        public override Task<IEnumerable<T>> GetAll()
        {
            return GetBasicCrudDal().GetAll(x => x.User.Id == _user.Id);
        }

        public override Task<T> Delete(int id)
        {
            return GetBasicCrudDal().Delete(x => x.User.Id == _user.Id && x.Id == id);
        }
    }
}