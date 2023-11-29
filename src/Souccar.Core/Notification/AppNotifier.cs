using Abp.Localization;
using Abp.Notifications;
using Abp;
using Souccar.Authorization.Users;
using Souccar.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Notification
{
    public class AppNotifier : SouccarDomainServiceBase, IAppNotifier
    {
        private readonly INotificationPublisher _notificationPublisher;

        public AppNotifier(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }

        public async Task SendMaterialExpiryDate(User user, string name, DateTime date)
        {
            var param = new string[2] {name, date.ToString("dd/MM/yyyy") };
            await _notificationPublisher.PublishAsync(
                AppNotificationNames.MaterialExpirationWarning,
                new MessageNotificationData(L("The{0}MaterialWillExpireOn{1}", param)),
                severity: NotificationSeverity.Warn,
                userIds: new[] { user.ToUserIdentifier() }
                );
        }
    }
}