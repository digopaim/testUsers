using Newtonsoft.Json;
using Domain.Core.Configuration;
using Domain.Core.Models.ViewModel;
using Domain.Core.Notifications;
using Domain.Core.Services.HttpClientHelper.Interface;
using Domain.Services.DomainMessage.Interface;
using System;

namespace Services.Service
{
    public class MessageNotificationService : IMessageNotificationService
    {
        private IDomainMessageConfiguration domainMessageConfiguration;
        private IHttpClientHelper httpClientHelper;

        public MessageNotificationService(IDomainMessageConfiguration DomainMessageConfiguration,
            IHttpClientHelper HttpClientHelper)
        {
            domainMessageConfiguration = DomainMessageConfiguration;
            httpClientHelper = HttpClientHelper;
        }

        public DomainNotification GetMessage(int code)
        {
            var messageExternalServiceUrl = string.Format("{0}/{1}",domainMessageConfiguration.MessageExternalServiceUrl, code.ToString());

            try
            {
                var jsonResult = httpClientHelper.GetAsync(messageExternalServiceUrl);
                var mensagemViewModel = JsonConvert.DeserializeObject<MensagemViewModel>(jsonResult);
                return mensagemViewModel.MapToDomainNotification();
            }
            catch
            {
                return new DomainNotification(string.Empty, 0, string.Empty);
            }
        }
       
    }
}
