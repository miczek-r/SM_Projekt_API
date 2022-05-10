using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.User
{
    public class UserBaseDTO
    {

        [SwaggerSchema("The user identifier", Nullable = false)]
        public string Id { get; set; } = string.Empty;
        [SwaggerSchema("The user email", Nullable = false)]
        public string Email { get; set; } = string.Empty;
        [SwaggerSchema("The user first name")]
        public string? FirstName { get; set; }
        [SwaggerSchema("The user last name")]
        public string? LastName { get; set; }
    }
}
