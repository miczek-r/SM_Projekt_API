using Core.Entities;
using Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class PollSpecification : BaseSpecification<Poll>
    {
        public PollSpecification(Expression<Func<Poll, bool>> criteria)
        : base(criteria)
        {
            AddInclude(x => x.AllowedUsers);
            AddInclude(x => x.Moderators);
            AddInclude(x => x.Questions);
            AddInclude($"{nameof(Poll.AllowedUsers)}.{nameof(PollAllowed.User)}");
            AddInclude($"{nameof(Poll.Moderators)}.{nameof(PollAllowed.User)}");
            AddInclude($"{nameof(Poll.Questions)}.{nameof(Question.Answers)}");
        }
    }
}
