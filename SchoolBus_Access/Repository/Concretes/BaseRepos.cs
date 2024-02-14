using Microsoft.EntityFrameworkCore;
using SchoolBus_Access.Context;
using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Model.Entities.Abstract;

namespace SchoolBus_Access.Repository.Concretes
{
    public class BaseRepos<T> : IBaseRepos<T> where T : BaseEntity,new()
    {
 
        internal readonly SchoolBus_Context _context;
        internal readonly DbSet<T> _entity;

        public BaseRepos()
        {
            _context = new SchoolBus_Context();
            _entity = _context.Set<T>();
        }


        public void Add(T entity)
        {
            if (entity == null) throw new Exception("Entity Is NULL");
            _entity.Add(entity);
        }

        public ICollection<T> GetAll()
        {
            return _entity.ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(a => a.Id == id);
        }

        public void Remove(T entity)
        {
            if (entity == null) throw new Exception("Entity Is NULL");

            var isChechk = _context.Set<T>().FirstOrDefault(a => a.Id == entity.Id);

            if (isChechk == null) throw new Exception("Entity Not Found");
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new Exception("Entity Is NULL");

            var isChechk = _context.Set<T>().FirstOrDefault(a => a.Id == entity.Id);

            if (isChechk == null) throw new Exception("Entity Not Found");
         
            _context.Set<T>().Attach(entity);
        }
    }

}

