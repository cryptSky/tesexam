using Hub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using MongoDB.Bson;

namespace Hub.Services
{
    public class QuizService : IQuizService
    {
        private IUnitOfWork _uow;
        public QuizService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task Create(QuizDO quiz)
        {
            await _uow.QuizRepository.Add(quiz);
        }

        public async Task<QuizDO> Get(ObjectId key)
        {
            return await _uow.QuizRepository.GetByKey(key);
        }
    }
}
