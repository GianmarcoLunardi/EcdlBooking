

using System.Linq.Expressions;

namespace EcdlBooking.Services.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        public Task add(T Entity);

        Task delete(T Entity);




        IEnumerable<T> GetAll(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = null
        );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );


    }
}
