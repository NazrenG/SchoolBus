using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Concretes
{
    public class RouteRepos : BaseRepos<Route>, IRouteRepos
    {
        public List<string> GetAllRouteName()
        {
            return _context.Routes.Select(r => r.Name).ToList();
        }

        public int GetBusId(int routeId)
        {
            var bus = _context.Routes.FirstOrDefault(r => r.Id==routeId);
            return bus != null ? bus.BusId : 0;
        }

        public int GetRouteId(string routeName)
        {
           var route= _context.Routes.FirstOrDefault(r => r.Name == routeName);
            return route != null ? route.Id : 0;
        }
    }
}
