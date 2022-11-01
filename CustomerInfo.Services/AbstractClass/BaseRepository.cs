using CustomerInfo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Services.AbstractClass
{
    public class BaseRepository<T> where T : class
    {
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        protected ApplicationDbContext _context { get; set; }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Create(List<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }

        public void Update(List<T> entity)
        {
            _context.Set<T>().UpdateRange(entity);
        }
    }
}
