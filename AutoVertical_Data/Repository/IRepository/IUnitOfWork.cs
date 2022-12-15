using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
           void Save();
           public IVehicleRepository vehicle { get;}
           public ICarRepository car { get;}
           public ITruckRepository truck { get;}
           public IMotorcycleRepository motorcycle { get;}
           public IGalleryRepository gallery{ get;}
    }
}
