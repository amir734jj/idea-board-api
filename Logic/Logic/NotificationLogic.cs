using System.Collections.Generic;
using System.Threading.Tasks;
using Logic.Extensions;
using Logic.Interfaces;
using Models.Entities;

namespace Logic.Logic
{
    public class NotificationLogic : INotificationLogic
    {
        private readonly IUserLogic _userLogic;

        public NotificationLogic(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public async Task<List<UserNotification>> Collect(User user)
        {
            var notifications = (await _userLogic.Get(user.Id)).UserNotifications ?? new List<UserNotification>();

            return notifications;
        }

        public async Task MarkAllNotificationsAsSeen(User user)
        {
            await _userLogic.Update(user.Id, usr =>
            {
                foreach (var notification in usr.UserNotifications)
                {
                    notification.Collected = true;
                }
            });
        }
        
        public async Task AddNotification(User user, UserNotification notification)
        {
            await _userLogic.Update(user.Id, usr => usr.UserNotifications.Add(notification));
        }
    }
}