using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Concretes
{
    public class ClassRepos : BaseRepos<Class>, IClassRepos
    {
        public int FindId(string name)
        {
            var className= _context.Classes.FirstOrDefault(c => c.Name == name);  
            return className != null ? className.Id : 0;
        }

        public List<string> GetAllClass()
        {
            return _context.Classes.Select(c => c.Name).ToList();
        }
    }
}
