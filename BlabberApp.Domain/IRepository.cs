using System.Collections.Generic;

namespace BlabberApp.Domain
{
    public interface IRepository<T> where T : IDatum
    {
        T Add(T item);
        void Delete(T item);
        void Update(T item);
        IEnumerable<T> GetAll();
        T GetByID(string sysId);
        T GetByUserID(string userID);
    }
}