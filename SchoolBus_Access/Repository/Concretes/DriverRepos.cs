using Microsoft.EntityFrameworkCore;
using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Model.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_Access.Repository.Concretes
{
    public class DriverRepos : BaseRepos<Driver>, IDrivesRepos
    {
        public ICollection<Driver> GetBusName()
        {
            return _context.Drivers.Include(x=>x.Bus).ToList();

        }
    }
}
