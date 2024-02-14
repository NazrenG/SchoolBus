using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Abstract
{
    public interface IDrivesRepos:IBaseRepos<Driver>
    {
        public ICollection<Driver> GetBusName();
    }
}
