using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Abstract
{
    public interface IParentRepos : IBaseRepos<Parent>
    {
        public List<string> GetAllFullname();
        public int FindId(string Fullname);
        public int FindIdForName(string name);

    }
}
