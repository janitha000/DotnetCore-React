using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using React.Entity;

namespace React.Repository.Generic
{
    public class Repositorybase<T> : IRepositryBase<T> where T : class, IEntitybase, new()
    {
        private DatabaseContext _context;

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetSingle(string id)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}