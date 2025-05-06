
using EcdlBooking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EcdlBooking.Services.Repository
{
    public class GenericRep<T> : IGenericRepo<T> where T : class
    {
        internal DbSet<T> Data;
        private readonly DbContext _context; 
        
        public GenericRep(DbContext context)
        {
            _context = context;
          
        }

        public async Task add(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
        }

        public async Task delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
        }

        public async Task edit(T Entity)
        {
             _context.Set<T>().Remove(Entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

    }
}


// throw new NotImplementedException();