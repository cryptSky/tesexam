using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using MongoDB.Bson;
using Data.Interfaces;
using MongoDB.Driver;
using Data.Infrastructure;

namespace Data.Repositories
{
    public class QuizRepository : GenericRepository<QuizDO>
    {
        public QuizRepository(TesexamDbContext context) : base(context)
        {
        }
    }
}
