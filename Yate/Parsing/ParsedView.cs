using System;
using System.Collections.Generic;
using System.IO;
using Common.Logging;
using CsQuery;
using Yate.Sheets;
using Yate.Sheets.AtRules;

namespace Yate.Parsing
{
    public class ParsedView : IParsedView, IBlockStructure
    {
        //todo: This should be interfaced out 
        public CQ Html { get; set; }
        public IList<RuleSet> RuleSets { get; private set; }
        public IList<IAtRule> AtRules { get; private set; }
        private readonly ILog _log = LogManager.GetCurrentClassLogger();

        public ParsedView(CQ html)
        {
            _log.Debug("Building a ParsedView.");

            if (html == null)
            {
                throw new ArgumentNullException("html");
            }

            Html = html;
            RuleSets = new List<RuleSet>();
            AtRules = new List<IAtRule>();
        }

        public string Render(IYateDataContext dataContext)
        {
            using (var stringWriter = new StringWriter())
            {
                WriteToTextWriter(stringWriter, dataContext);
                return stringWriter.ToString();
            }
        }

        public void WriteToTextWriter(TextWriter textWriter, IYateDataContext dataContext)
        {
            //this is done so i can run the parsed view with multiple contexts back to back 
            //without the first one corrupting the second one.
            var html = CQ.Create(Html);

            foreach (var atRule in AtRules)
            {
                atRule.Render(html, dataContext);
            }

            foreach (var ruleSet in RuleSets)
            {
                ruleSet.Render(html, dataContext);
            }

            html.Render(OutputFormatters.Default, textWriter);
        }
    }
}
