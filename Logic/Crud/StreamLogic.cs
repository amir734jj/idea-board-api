﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dal.Interfaces;
using EfCoreRepository.Interfaces;
using Logic.Abstracts;
using Logic.Interfaces;
using Microsoft.Extensions.Hosting;
using Models.Models;

namespace Logic.Crud
{
    public class StreamLogic : BasicLogicAbstract<Stream>, IStreamLogic
    {
        private readonly IBasicCrudType<Stream, int> _streamDal;

        private readonly Lazy<IStreamRipperManager> _streamRipperManager;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="streamRipperManager"></param>
        public StreamLogic(IEfRepository repository, Lazy<IStreamRipperManager> streamRipperManager)
        {
            _streamDal = repository.For<Stream, int>();
            _streamRipperManager = streamRipperManager;
        }

        public IBasicLogic<Stream> For(User user)
        {
            return new StreamLogicImpl(_streamDal, user, _streamRipperManager);
        }

        protected override IBasicCrudType<Stream, int> GetBasicCrudDal()
        {
            return _streamDal;
        }
    }

    public class AMir : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }

    public class StreamLogicImpl : BasicLogicAbstract<Stream>
    {
        private readonly IBasicCrudType<Stream, int> _streamDal;
        
        private readonly User _user;

        private readonly Lazy<IStreamRipperManager> _streamManager;

        public StreamLogicImpl(IBasicCrudType<Stream, int> streamDal, User user, Lazy<IStreamRipperManager> streamManager)
        {
            _streamDal = streamDal;
            _user = user;
            _streamManager = streamManager;
        }
        
        protected override IBasicCrudType<Stream, int> GetBasicCrudDal()
        {
            return _streamDal;
        }

        public override Task<Stream> Save(Stream instance)
        {
            instance.User = _user;

            return base.Save(instance);
        }
        
        public override async Task<IEnumerable<Stream>> GetAll()
        {
            return (await _streamDal.GetAll()).Where(x => x.User.Id == _user.Id).ToList();
        }

        public override async Task<Stream> Get(int id)
        {
            return (await _streamDal.GetAll()).Where(x => x.User.Id == _user.Id).FirstOrDefault(x => x.Id == id);
        }

        public override async Task<Stream> Delete(int id)
        {
            await _streamManager.Value.For(_user).Stop(id);
            
            return await base.Delete(id);
        }

        public override async Task<Stream> Update(int id, Stream dto)
        {
            await _streamManager.Value.For(_user).Stop(id);

            return await base.Update(id, dto);
        }
    }
}