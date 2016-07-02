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
        private TesexamDbContext _context;
       
        public QuizRepository QuizRepository
        {
            get
            {
                return _quizRepository ?? (_quizRepository = new QuizRepository(_context));
            }
        }

        public UnitOfWork(TesexamDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
