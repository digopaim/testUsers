using Domain.Core.Notifications;
using System;
using System.Collections.Generic;

namespace Domain.Core.Models.ViewModel
{
    public class MensagemViewModel
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public int IdAreaNegocio { get; set; }
        public IList<SolucaoViewModel> Solucoes { get; set; }

        public DomainNotification MapToDomainNotification()
        {
            var domainNotification = new DomainNotification(Id.ToString(),
                    Codigo,
                    Descricao);

            foreach (var solution in Solucoes)
            {
                domainNotification.AddSolution(solution.Id,
                    solution.Description,
                    solution.IDMessage,
                    solution.UserID,
                    solution.DateMessage,
                    solution.Likes);
            }

            return domainNotification;
        }
    }
}
