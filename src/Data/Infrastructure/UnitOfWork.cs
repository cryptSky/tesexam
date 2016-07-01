using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private QuizRepository _quizRepository;
        private IServiceProvider _provider;

        public QuizRepository QuizRepository
        {
            get
            {
                return _quizRepository ?? (_quizRepository = new QuizRepository((IMongoDbContext)_provider.GetService(typeof(IMongoDbContext))));
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
