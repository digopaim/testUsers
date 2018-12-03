using Infra.Data.Context;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.User.Model;
using User.Domain.User.Repository;

namespace User.Infra.Data.User.Repository
{
    public class UserRepository : Repository<Users, decimal>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
