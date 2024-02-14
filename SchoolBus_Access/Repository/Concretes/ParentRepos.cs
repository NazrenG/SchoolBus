using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Concretes
{
    public class ParentRepos : BaseRepos<Parent>, IParentRepos
    {
        public int FindId(string Fullname)
        {
            var parent = _context.Parents.FirstOrDefault(b => b.Name+" "+b.LastName == Fullname);
            return parent != null ? parent.Id : 0;
        }

        public int FindIdForName(string name)
        {
            var parent = _context.Parents.FirstOrDefault(b => b.Name==name );
            return parent != null ? parent.Id : 0;
        }

        public List<string> GetAllFullname()
        {
            return _context.Parents.Select(x => x.Name+" "+x.LastName).ToList();
        }
    }
}
