using System;
using Domain.Core.Events;

namespace Domain.Core.Notifications
{
    public class DomainSolutionNotification
    {
        public DomainSolutionNotification(Guid? id, string descricao, Guid? idMensagem, Guid? idUsuario, DateTime data, int likes)
        {
            Id = id;
            Descricao = descricao;
            IdMensagem = idMensagem;
            IdUsuario = idUsuario;
            Data = data;
            Likes = likes;
        }

        public Guid? Id { get; private set; }
        public string Descricao { get; private set; }
        public Guid? IdMensagem { get; private set; }
        public Guid? IdUsuario { get; private set; }
        public DateTime Data { get; private set; }
        public int Likes { get; private set; }
    }
}