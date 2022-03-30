using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepositoryImp : RepositoryImp<User>, UserRepository
    {
        public UserRepositoryImp(IdentityDbContext dbContext) : base(dbContext)
        {
        }
    }
}
