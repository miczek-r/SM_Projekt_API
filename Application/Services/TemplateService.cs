using Application.Interfaces;
using Stubble.Core.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TemplateService : ITemplateService
    {

        private const string _templatesPathPart = "Templates";

        public async Task<string> Render(string templateName, Dictionary<string, object> replacementData)
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), _templatesPathPart, templateName);
            var stubble = new StubbleBuilder().Build();

            using var streamReader = new StreamReader(templatePath);
            return await stubble.RenderAsync(await streamReader.ReadToEndAsync(), replacementData);

        }
    }
}
