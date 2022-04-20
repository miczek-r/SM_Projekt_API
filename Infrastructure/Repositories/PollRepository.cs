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
    public class PollRepository : Repository<Poll>, Core.Repositories.IPollRepository
    {
        public PollRepository(IdentityDbContext dbContext) : base(dbContext)
        {
        }
    }
}
