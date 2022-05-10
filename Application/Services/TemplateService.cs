using Application.Interfaces;
using Application.Templates;
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

        public async Task<string> Render(string templateName, Dictionary<string, object> replacementData)
        {
            string template = "";
            switch (templateName)
            {
                case "confirmation":
                    template = ConfirmationTemplate.Template;
                    break;
                case "pollStarted":
                    template = PollStartedTemplate.Template;
                    break;
                case "pollEnded":
                    template = PollEndedTemplate.Template;
                    break;
            }
            var stubble = new StubbleBuilder().Build();

            return await stubble.RenderAsync(template, replacementData);

        }
    }
}
