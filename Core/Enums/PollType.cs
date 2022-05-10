using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    [SwaggerSchema("The enumerable determinig type of the poll")]
    public enum PollType
    {
        Private,
        Public,
        Protected,
        Hidden
    }
}
