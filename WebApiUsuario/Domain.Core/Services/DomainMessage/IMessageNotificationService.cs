using Domain.Core.Notifications;

namespace Domain.Services.DomainMessage.Interface
{
    public interface IMessageNotificationService
    {
        DomainNotification GetMessage(int code);
    }
}
