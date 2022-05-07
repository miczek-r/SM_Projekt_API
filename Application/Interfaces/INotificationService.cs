using Application.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationLiteDTO>> GetAll();
        Task<NotificationBaseDTO> Get(int notificationId);
        Task Delete(int notificationId);
        Task<int> Create(NotificationCreateDTO notificationCreateDTO);
        Task SetAsSeen(int notificationId);

    }
}
