using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Abstract
{
    public interface IRouteRepos : IBaseRepos<Route>
    {
        public List<string> GetAllRouteName();
        public int GetRouteId(string routeName);
        public int GetBusId(int routeId);
    }
}
