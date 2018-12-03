using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User.Model
{
    public class Users : Entity<int>
    {
        public string Name { get; set; }
       public int Age { get; set; }
        public string DocumentNumber { get; set; }
    }
}
