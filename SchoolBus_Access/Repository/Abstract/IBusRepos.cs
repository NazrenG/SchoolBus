using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Abstract
{
    public interface IBusRepos:IBaseRepos<Bus>
    {
        public ICollection<Bus> GetDriverName();
        public List<string> GetAllBusName();
        public List<string> GetAllBusNumber();
        public int FindId(string name); 
        public int FindIdForNameAndNumber(string name,string number);
    }
}
