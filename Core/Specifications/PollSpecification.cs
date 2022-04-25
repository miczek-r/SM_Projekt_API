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
            AddInclude(x => x.Questions);
            AddInclude($"{nameof(Poll.Questions)}.{nameof(Question.Answers)}");
        }
    }
}
