using System.Collections.Generic;
using CRUD_series.Model;

namespace CRUD_series.Repository
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T entity);
        void Exclude(int id);
        void Update(int id, T entity);
        int NextId();
        T FindByID(int id);
    }
}