using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Abstract
{
    public interface IClassRepos : IBaseRepos<Class>
    {
        public List<string> GetAllClass();
        public int FindId(string name);
    }
}
