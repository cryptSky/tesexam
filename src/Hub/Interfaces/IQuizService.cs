using Data.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Interfaces
{
    public interface IQuizService
    {
        Task Create(QuizDO quiz);
        Task<QuizDO> Get(ObjectId key);
    }
}
