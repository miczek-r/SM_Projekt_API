using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITemplateService
    {
        Task<string> Render(string templateName, Dictionary<string,object> replacementData);
    }
}
