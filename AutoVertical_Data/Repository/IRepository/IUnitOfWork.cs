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
           public IApplicationUserRepository applicationUser { get;}
           public IMessageRepository messages { get;}
           public IConversationRepository conversation { get;}
           public IAdvertStatsRepository advertStats { get;}
           public IAdvertisementRepositoryt advertisement{ get;}
           public INotyficationRepository notyfications{ get;}
           public IUserFollowedVehicleRepository userFollowedVehicle { get;}
    }
}
