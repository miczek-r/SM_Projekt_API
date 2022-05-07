using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NotificationRepository : Repository<Notification>, Core.Repositories.INotificationRepository
    {
        public NotificationRepository(IdentityDbContext dbContext) : base(dbContext)
        {
        }
    }
}
