using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.User.Model;

namespace User.Domain.User.Repository
{
    public interface IUserRepository : IRepository<Users, decimal>
    {
    }
}
