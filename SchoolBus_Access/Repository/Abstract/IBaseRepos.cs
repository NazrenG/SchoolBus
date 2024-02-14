using Microsoft.EntityFrameworkCore;
using SchoolBus_Model.Entities.Abstract;

namespace SchoolBus_Access.Repository.Abstract
{
    public interface IBaseRepos<T> where T : BaseEntity,new()
    {
        ICollection<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Save();
    }
}
