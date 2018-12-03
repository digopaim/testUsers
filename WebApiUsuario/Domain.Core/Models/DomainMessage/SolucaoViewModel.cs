using System;

namespace Domain.Core.Models.ViewModel
{
    public class SolucaoViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid IDMessage { get; set; }
        public Guid UserID { get; set; }
        public DateTime DateMessage { get; set; }
        public int Likes { get; set; }
    }
}
