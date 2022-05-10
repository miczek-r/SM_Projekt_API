using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Answer
{
    public class AnswerBaseDTO
    {
        [SwaggerSchema("The answer identifier")]
        public int Id { get; set; }
        [SwaggerSchema("The answer text", Nullable = false)]
        public string Text { get; set; } = string.Empty;
    }
}
