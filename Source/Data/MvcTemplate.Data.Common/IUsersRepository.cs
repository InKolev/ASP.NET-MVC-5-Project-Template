namespace MvcTemplate.Data.Common
{
    using System.Linq;

    public interface IUsersRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T GetById(string id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}
