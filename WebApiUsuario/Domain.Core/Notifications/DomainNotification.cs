using Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public int Code { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        List<DomainSolutionNotification> _solutions;
        public IReadOnlyCollection<DomainSolutionNotification> Solutions {
            get
            {
                return _solutions;
            }
        }

        public DomainNotification(string key, string value, int version = 1)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = version;
            Key = key;
            Value = value;
        }

        public DomainNotification(string key, int code, string value, int version = 1)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = version;
            Key = key;
            Code = code;
            Value = value;
            _solutions = new List<DomainSolutionNotification>();
        }

        public void AddSolution(Guid? id, string descricao, Guid? idMensagem, Guid? idUsuario, DateTime data, int likes)
        {
            if (HasCode())
                _solutions.Add(new DomainSolutionNotification(id, descricao, idMensagem, idUsuario, data, likes));
        }
        
        public bool HasCode()
        {
            if (Code > 0)
                return true;

            return false;
        }

        public void ResetCode()
        {
            if (_solutions.Count == 0)
                Code = 0;
        }
    }
}